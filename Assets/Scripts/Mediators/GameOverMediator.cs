using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using UnityEngine;

public class GameOverMediator : BaseMediator<GameOverView>
{
    private GameDataContainer _gamedataContainer;
    private ViewsStatusDataContainer _viewsStatusDataContainer;

    public GameOverMediator(GameOverView view)
    {
        base.view = view;
        Initialize();
        SubscribeEvents();

    }

    private void Initialize()
    {
        _gamedataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
        _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
    }
    #region EventsSubscribeAndUnsubscribe

    private void SubscribeEvents()
    {

        EventManager.Instance.AddEvent(GameDataKeys.GameOver, EnableGameOver);


    }

    private void UnsubscribeEvents()
    {

        EventManager.Instance.RemoveEvent(GameDataKeys.GameOver, EnableGameOver);

    }

    private void EnableGameOver()
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
        _gamedataContainer.GameOver = false;
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;
        view.HideGameOver();
    }
}
