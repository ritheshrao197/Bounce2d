using Bounce.ViewLayer;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : BaseView
{
    private SettingsMediator mediator;
    [SerializeField] private Button Soundbtn;
    [SerializeField] private Button Musicbtn;
    [SerializeField] private Button PauseBtn;
    Color fullAlphaWhite = new Color(1f, 1f, 1f, 1f);
    Color partialAlphaWhite = new Color(1f, 1f, 1f, 0.5f);


    private void Start()
    {
        Initialize();

    }


    private void Initialize()
    {
        mediator = new SettingsMediator(this);
        Musicbtn.onClick.AddListener(OnMusicButtonClick);
        Soundbtn.onClick.AddListener(OnSoundButtonClick);
        PauseBtn?.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnMusicButtonClick()
    {
        mediator.OnMusicButtonClick();
    }
    private void OnSoundButtonClick()
    {
        mediator.OnSoundButtonClick();
    }
    private void OnPauseButtonClick()
    {
        mediator.OnPauseButtonClick();
    }
    public void SoundSwitch(bool on)
    {
        Soundbtn.image.color = on ? fullAlphaWhite : partialAlphaWhite;
    }
    public void MusicSwitch(bool on)
    {
        Musicbtn.image.color = on ? fullAlphaWhite : partialAlphaWhite;
    }
}
