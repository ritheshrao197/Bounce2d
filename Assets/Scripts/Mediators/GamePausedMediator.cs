using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using UnityEngine;

public class GamePausedMediator : BaseMediator<GamePausedView>
{
    private GameDataContainer _gamedataContainer;
    private ViewsStatusDataContainer _viewsStatusDataContainer;

    public GamePausedMediator(GamePausedView view)
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

        EventManager.Instance.AddEvent(GameDataKeys.Pause, SetPauseScreen);


    }

    private void UnsubscribeEvents()
    {

        EventManager.Instance.RemoveEvent(GameDataKeys.Pause, SetPauseScreen);

    }

    private void SetPauseScreen()
    {
        if(_gamedataContainer.Pause)
        view.ShowGamePause();
        else
            view.HideGamePaused();
    }



    #endregion



    internal void OnQuitButtonClick()
    {
        Application.Quit();
    }

    internal void OnPlayButtonClick()
    {
        _gamedataContainer.Pause = false;
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;
        view.HideGamePaused();
    }
}
