using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using System;
using UnityEngine;

public class MainMenuMediator : BaseMediator<MainMenuView>
{
    private GameDataContainer _gamedataContainer;
    private ViewsStatusDataContainer _viewsStatusDataContainer;

    public MainMenuMediator(MainMenuView view)
    {
        base.view = view;
        Initialize();
      //  SubscribeEvents();

    }

    private void Initialize()
    {
        _gamedataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
        _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
    }
    #region EventsSubscribeAndUnsubscribe

 /*   private void SubscribeEvents()
    {

        EventManager.Instance.AddEvent(GameDataKeys.GameOver, EnableMainMenu);


    }

    private void UnsubscribeEvents()
    {

        EventManager.Instance.RemoveEvent(GameDataKeys.GameOver, EnableMainMenu);

    }*/

    private void EnableMainMenu()
    {
        view.ShowMainMenu();
    }



    #endregion



    internal void OnQuitButtonClick()
    {
        Application.Quit();
    }

    internal void OnPlayButtonClick()
    {
        _gamedataContainer.GameStarted = true;
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;
        view.HideMainMenu();
    }
}
