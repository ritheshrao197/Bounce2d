using Bounce.ViewLayer;
using Bounce.Utilities;
using Bounce.EventSystem;
using Bounce.DataModel;
using UnityEngine;
using System;
using System.Collections.Generic;
using Bounce.DataLayer;
using System.Linq;

namespace Bounce.MediatorLayer
{

    public class GameAudioMediator : BaseMediator<GameAudioView>
    {
        #region Variables


        private SettingsDataContainer settingsDataContainer;
        private GameDataContainer gameDataContainer;
        private ViewsStatusDataContainer _viewsStatusDataContainer;


        #endregion

        #region Constructor

        public GameAudioMediator(GameAudioView audioView)
        {
            view = audioView;
            Initialize();
            SubscribeEvents();

        }

        #endregion

        #region UnityMethods

        public void Start()
        {

        }

        #endregion

        #region Initialize

        private void Initialize()
        {
            settingsDataContainer = ServiceLocator.Instance.Get<SettingsDataContainer>();
            _viewsStatusDataContainer = ServiceLocator.Instance.Get<ViewsStatusDataContainer>();
            gameDataContainer = ServiceLocator.Instance.Get<GameDataContainer>();
        }



        #endregion

        #region EventsSubscribeAndUnsubscribe

        private void SubscribeEvents()
        {
            EventManager.Instance.AddEvent(GameDataKeys.GameInitialised, MusicSettingChanged);
            EventManager.Instance.AddEvent(GameDataKeys.LevelComplete, MusicSettingChanged);

            EventManager.Instance.AddEvent(GameSettingsEventsKey.OnUpdateBGMVolumeSetting, MusicSettingChanged);
            EventManager.Instance.AddEvent(ViewsStatusEventsKey.OnSFXUpdate, PlySFXSound);

        }


        private void UnsubscribeEvents()
        {
            EventManager.Instance.RemoveEvent(GameDataKeys.GameInitialised, MusicSettingChanged);
            EventManager.Instance.RemoveEvent(GameDataKeys.LevelComplete, MusicSettingChanged);

            EventManager.Instance.RemoveEvent(GameSettingsEventsKey.OnUpdateBGMVolumeSetting, MusicSettingChanged);
            EventManager.Instance.RemoveEvent(ViewsStatusEventsKey.OnSFXUpdate, PlySFXSound);

        }

        #endregion

        #region set music

        private void MusicSettingChanged()
        {
            var volumeRange = 0.3f;
            PlayBGM(volumeRange, gameDataContainer.CurrentLevel);
        }

        private void ChangeMusicVolume(float volumeRange)
        {
            view.ChangeBGMusicVolume(volumeRange);
        }

        #endregion

        #region PlaySFX

        private void PlySFXSound()
        {
            if (!CanPlaySFX())
            {
              //         return;
            }

            PlaySFX(_viewsStatusDataContainer.SFXType);
        }





        private bool CanPlaySFX()
        {
            return settingsDataContainer.CanPlaySound == true;
        }

        #endregion

        #region Load and play audios
        private Dictionary<SFXType, AudioClip> cachedClips = new Dictionary<SFXType, AudioClip>();


        public void PlaySFX(SFXType SFXType)
        {
            if (settingsDataContainer.CanPlaySound)
            {
           
            AudioClip clip = GetCachedClip(SFXType);
            if (clip != null)
            {
                view.PlayAudioClip(clip);

                }
            }
            else
                view.StopSounds();
        }

        public void PlayBGM(float volume, int index)
        {
            Debug.Log("PlayBGM");
            if (settingsDataContainer.CanPlayMusic)
            {
                index = index % view.AudioManagerData.bGMs.Count();
                AudioClip clip = view.AudioManagerData.bGMs[index];
                if (clip != null)
                {
                    view.StartPlayBGMusic(volume, clip);
                }
            }
            else
                view.StopMusic();
        }

        private AudioClip GetCachedClip(SFXType type)
        { 
            if (!cachedClips.ContainsKey(type))
            {
                AudioClip clip = view.AudioManagerData.GetAudioClipByType(type);
                cachedClips.Add(type, clip);
            }
            return cachedClips[type];
        }
        #endregion
        

        #region Destructor

        ~GameAudioMediator()
        {
            UnsubscribeEvents();
            view = null;
        }

        #endregion
    }
}

