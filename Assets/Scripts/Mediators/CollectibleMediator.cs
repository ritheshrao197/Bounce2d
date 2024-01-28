using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.MediatorLayer;
using Bounce.Utilities;

public class CollectibleMediator : BaseMediator<Collectible>
{
    private GameDataContainer _gameDataContainer;
    private ViewsStatusDataContainer _viewsStatusDataContainer;

    public CollectibleMediator(Collectible collectibleView)
    {
        view = collectibleView;
        Initialize();
    }

    private void Initialize()
    {
        _gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
        _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
    }

    internal void Start()
    {
        SetUpStartPoint();
    }
    private void SetUpStartPoint()
    {
        if (view.CollectibleType==CollectibleType.StartPoint)
        {
            _gameDataContainer.StartPosition = view.gameObject.transform.position;
        }
    }
    internal void HandleCollectible()
    {
        switch (view.CollectibleType)
        {
            case CollectibleType.Health:
                if(_gameDataContainer.Health<3)
                _gameDataContainer.Health++;
                view.OnCollected();
                _viewsStatusDataContainer.SFXType = SFXType.Health;

                break;
            case CollectibleType.Coin:
                _gameDataContainer.Coin++;
                view.OnCollected();
                _viewsStatusDataContainer.SFXType = SFXType.Coin;

                break;
            case CollectibleType.Obstacle:
                _gameDataContainer.ObstacleHit = true;
                _viewsStatusDataContainer.SFXType = SFXType.Obsitcle;
                if (_gameDataContainer.Health > 1)
                    _gameDataContainer.Health--;
                else
                    _gameDataContainer.GameOver = true;
                break;
            case CollectibleType.EndPoint:
                _gameDataContainer.CurrentLevel++;
                _gameDataContainer.LevelComplete = true;
                _viewsStatusDataContainer.SFXType = SFXType.LevelComplete;

                break;
        }
    }
}
