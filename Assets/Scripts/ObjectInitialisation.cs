using Bounce.CoreSystem;
using Bounce.DataLayer;
using Bounce.EventSystem;
using Bounce.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bounce
{
    public class ObjectInitialisation : MonoBehaviour
    {
        private SettingsDataContainer _settingsDataContainer;
        private GameDataContainer _gameDataContainer;
        private ViewsStatusDataContainer _viewsStatusDataContainer;
        private GameDataHandler _gameDataHandler;

        [SerializeField] private GameObject _mainMenu;

        private void Awake()
        {
            SetUpDataContainer();
            Initialisation();
            RegisterToServiceLocator();
            SetUpCoreSystem();
            InitialiseCoreSystem();

            EnableMainMenu();
        }

        private void EnableMainMenu()
        {
            _mainMenu.SetActive(true);
        }

        private void SetUpCoreSystem()
        {
            _gameDataHandler = new GameDataHandler();

        }

        private void Start()
        {
            _gameDataContainer.InitialiseGame=true;
        }
        private void RegisterToServiceLocator()
        {
            ServiceLocator.Instance.Register(_settingsDataContainer);
            ServiceLocator.Instance.Register(_gameDataContainer);
            ServiceLocator.Instance.Register(_viewsStatusDataContainer);
        }

        private void SetUpDataContainer()
        {
            _settingsDataContainer = new SettingsDataContainer();
            _gameDataContainer = new GameDataContainer();
            _viewsStatusDataContainer = new ViewsStatusDataContainer();
        }

        private  void Initialisation()
        {
            ServiceLocator.Initiailze();
            EventManager.Initiailze();
        }
        private void InitialiseCoreSystem()
        {
            _gameDataHandler.Initialize();
        }
    }


}
