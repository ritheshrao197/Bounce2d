using Bounce;
using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using System;
using UnityEngine;
namespace Bounce
{
    public class PlayerControllerMediator : BaseMediator<PlayerControllerView>
    {
        private GameDataContainer _gameDataContainer;
        private ViewsStatusDataContainer _viewsStatusDataContainer;
        private int _jumpsRemaining = 2;

        public PlayerControllerMediator(PlayerControllerView playerControllerView)
        {
            view = playerControllerView;
            Initialize();
        }

        private void Initialize()
        {
            _gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
            _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
        }

        internal void Start()
        {
            SubscribeEvents();
        }
        #region EventsSubscribeAndUnsubscribe

        private void SubscribeEvents()
        {

            EventManager.Instance.AddEvent(GameDataKeys.ObstacleHit, ResetAfterObstacleHit);
            EventManager.Instance.AddEvent(GameDataKeys.LevelComplete, ResetAfterObstacleHit);
            EventManager.Instance.AddEvent(GameDataKeys.GameStarted, UpdatePlyerStatusOnPlay);
            EventManager.Instance.AddEvent(GameDataKeys.GameOver, UpdatePlyerStatusOnGameOver);


        }

        private void UnsubscribeEvents()
        {
            EventManager.Instance.RemoveEvent(GameDataKeys.ObstacleHit, ResetAfterObstacleHit);
            EventManager.Instance.RemoveEvent(GameDataKeys.LevelComplete, ResetAfterObstacleHit);
            EventManager.Instance.RemoveEvent(GameDataKeys.GameStarted, UpdatePlyerStatusOnPlay);
            EventManager.Instance.RemoveEvent(GameDataKeys.GameOver, UpdatePlyerStatusOnGameOver);


        }


        private void ResetAfterObstacleHit()
        {
            view.ResetPosition(_gameDataContainer.StartPosition);
        }



        #endregion
        internal void HandleInput()
        {
            if (!_gameDataContainer.GameOver && ! _gameDataContainer.Pause)
            {
                float horizontalInput = Input.GetAxis("Horizontal");


                if (horizontalInput!=0)
                {

                    Vector2 movement = new Vector2(horizontalInput, 0).normalized;
                    view.player.AddForce(movement * PlayerConstants.Speed);
                 
                }
                
                if (Input.GetButtonDown("Vertical") && _jumpsRemaining > 0)
                {
                    float verticalInput = Input.GetAxis("Vertical");
                    if (verticalInput > 0)
                    {
                        view.player.velocity = new Vector2(view.player.velocity.x, PlayerConstants.JumpSpeed);
                        view.player.AddForce(new Vector2(0, PlayerConstants.JumpSpeed));
                        _jumpsRemaining--;
                        _viewsStatusDataContainer.SFXType = SFXType.Jump;
                    }
                }
              
            }
        }

        private void UpdatePlyerStatusOnPlay()
        {
            view.player.bodyType = RigidbodyType2D.Dynamic;
        }
        private void UpdatePlyerStatusOnGameOver()
        {
            view.player.bodyType = RigidbodyType2D.Static;
        }
        internal void HandleGroundCollision(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
               _jumpsRemaining = PlayerConstants.MaxJumps;

            }
        }
        ~PlayerControllerMediator()
        {
            UnsubscribeEvents();
        }
    }
}