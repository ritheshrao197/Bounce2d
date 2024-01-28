using Bounce.ViewLayer;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseView
{
    private GameOverMediator _mediator;
    [SerializeField] private Button _playbtn;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _mediator = new GameOverMediator(this);
        _playbtn.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        _mediator.OnPlayButtonClick();
    }
    internal void ShowMainMenu()
    {
        _canvasGroup.alpha = 1f; 
        _canvasGroup.interactable = true; 
        _canvasGroup.blocksRaycasts = true; 
    }

    internal void HideGameOver()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false; 
        _canvasGroup.blocksRaycasts = false; 
    }
}
