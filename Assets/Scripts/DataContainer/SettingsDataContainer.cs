
using Bounce.EventSystem;
using Bounce.Utilities;

public class SettingsDataContainer : IGameServices
{
    // To Play Sound
    private bool _canPlaySound =true;


    // To Control BGM
    private bool _canPlayMusic =true;

    public bool CanPlaySound
    {
        get => _canPlaySound;

        set
        {
            _canPlaySound = value;
            EventManager.Instance.InvokeEvent(GameSettingsEventsKey.OnUpdatePlaySoundSetting);
        }
    }


    public bool CanPlayMusic
    {
        get => _canPlayMusic;

        set
        {
            _canPlayMusic = value;
            EventManager.Instance.InvokeEvent(GameSettingsEventsKey.OnUpdateBGMVolumeSetting);
        }
    }
}
