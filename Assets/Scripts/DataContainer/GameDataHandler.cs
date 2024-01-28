
using Bounce.EventSystem;
using Bounce.Utilities;
using System;
using UnityEngine;
namespace Bounce.CoreSystem
{


    public class GameDataHandler : CoreSystem
    {
        #region Variables

        private GameDataContainer _gameDataContainer;
    

        #endregion

        #region Initialize

        public void Initialize()
        {
            _gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();

            SubscribeEvents();
        }

        #endregion

        #region EventsSubscribeAnsUnsubscribe

        private void SubscribeEvents()
        {
            EventManager.Instance.AddEvent(GameDataKeys.GameStarted, ResetGameData);
        }

        private void UnsubscribeEvents()
        {
            EventManager.Instance.RemoveEvent(GameDataKeys.GameStarted, ResetGameData);
        }

        #endregion



        #region Uninitialize

        public void Uninitialize()
        {
            UnsubscribeEvents();
        }

        #endregion


        private void ResetGameData()
        {
            _gameDataContainer.Health = PlayerConstants.MaxHealth;
        }

        #region Destructor

        ~GameDataHandler()
        {
            _gameDataContainer = null;
            UnsubscribeEvents();
        }

        #endregion
    }
}