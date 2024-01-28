using Bounce.DataLayer;
using Bounce.DataModel;
using Bounce.EventSystem;
using Bounce.MediatorLayer;
using Bounce.Utilities;
using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class SettingsMediator : BaseMediator<SettingsView>
{
    private SettingsDataContainer _settingsDataContainer;
    private ViewsStatusDataContainer _viewsStatusDataContainer;
    private GameDataContainer _gamedataContainer;

    public SettingsMediator(SettingsView view)
    {
        base.view = view;
        Initialize();
        SubscribeEvents();

    }

    private void Initialize()
    {
        _settingsDataContainer = ServiceLocator.Instance.Get<SettingsDataContainer>();
        _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
        _gamedataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
    }
    #region EventsSubscribeAndUnsubscribe

    private void SubscribeEvents()
    {

        EventManager.Instance.AddEvent(GameSettingsEventsKey.OnUpdateBGMVolumeSetting, MusicSettingChanged);
        EventManager.Instance.AddEvent(GameSettingsEventsKey.OnUpdatePlaySoundSetting, SFXSettingChanged);


    }

    private void UnsubscribeEvents()
    {

        EventManager.Instance.RemoveEvent(GameSettingsEventsKey.OnUpdateBGMVolumeSetting, MusicSettingChanged);
        EventManager.Instance.RemoveEvent(GameSettingsEventsKey.OnUpdatePlaySoundSetting, SFXSettingChanged);

    }



    #endregion

    private void MusicSettingChanged()
    {
        view.MusicSwitch(_settingsDataContainer.CanPlayMusic);
    }
    private void SFXSettingChanged()
    {
        view.SoundSwitch(_settingsDataContainer.CanPlaySound);

    }

    internal void OnMusicButtonClick()
    {
        _settingsDataContainer.CanPlayMusic = !_settingsDataContainer.CanPlayMusic;
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;

    }

    internal void OnSoundButtonClick()
    {
        _settingsDataContainer.CanPlaySound = !_settingsDataContainer.CanPlaySound;
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;

    }

    internal void OnPauseButtonClick()
    {
        _viewsStatusDataContainer.SFXType = SFXType.ButtonClick;
         _gamedataContainer.Pause = !_gamedataContainer.Pause;
        
    }
}
