using Bounce.EventSystem;
using Bounce.Utilities;
using Bounce.ViewLayer;
using System;
using UnityEngine;

namespace Bounce.MediatorLayer
{

    public class LevelGeneratorMediator : BaseMediator<LevelGeneratorView>
    {
        private GameDataContainer _gameDataContainer;

        public LevelGeneratorMediator(LevelGeneratorView levelGeneratorView)
        {
            view = levelGeneratorView;
            Initialize();
            SubscribeEvents();

        }

        private void Initialize()
        {
            _gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
        }
        #region EventsSubscribeAndUnsubscribe

        private void SubscribeEvents()
        {

            EventManager.Instance.AddEvent(GameDataKeys.GameStarted, GenerateLevel);
            EventManager.Instance.AddEvent(GameDataKeys.LevelComplete, GenerateLevel);

        }

        private void UnsubscribeEvents()
        {

            EventManager.Instance.RemoveEvent(GameDataKeys.GameStarted, GenerateLevel);
            EventManager.Instance.RemoveEvent(GameDataKeys.LevelComplete, GenerateLevel);
        }



        #endregion



        internal void GenerateLevel()
        {
            int i = _gameDataContainer.CurrentLevel-1;
         
            if (i >= 0 && i < view.levelData.LevelGameObjects.Count)
            {
                GameObject levelPrefab = view.levelData.LevelGameObjects[i];
                view.InstantiateLevel(levelPrefab);
             
            }
            else
            {
                Debug.LogError("Invalid index for level element: " + i);
            }

        }

    
    }

}