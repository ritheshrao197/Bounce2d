using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using System;

public class HUDMediator : BaseMediator<HUDView>
{
    private GameDataContainer gameDataContainer;

    public HUDMediator(HUDView hudView)
    {
        view = hudView;
        Initialize();
        SubscribeEvents();

    }

    private void Initialize()
    {
        gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
    }
    #region EventsSubscribeAndUnsubscribe

    private void SubscribeEvents()
    {

        EventManager.Instance.AddEvent(GameDataKeys.HealthUpdated, HealthUpdated);
        EventManager.Instance.AddEvent(GameDataKeys.LevelComplete, Levelpdated);
        EventManager.Instance.AddEvent(GameDataKeys.CoinUpdated, CoinUpdated);

    }

    private void UnsubscribeEvents()
    {

        EventManager.Instance.RemoveEvent(GameDataKeys.HealthUpdated, HealthUpdated);
        EventManager.Instance.RemoveEvent(GameDataKeys.LevelComplete, Levelpdated);
        EventManager.Instance.RemoveEvent(GameDataKeys.CoinUpdated, CoinUpdated);
    }



    #endregion
    private void CoinUpdated()
    {
        view.UpdateCoins(gameDataContainer.Coin);
    }

    private void Levelpdated()
    {
        view.UpdateLevel(gameDataContainer.CurrentLevel);
    }

    private void HealthUpdated()
    {
        view.UpdateHealth(gameDataContainer.Health);
    }

}
