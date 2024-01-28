using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using Bounce.MediatorLayer;
using Bounce.DataModel;
using System;

namespace Bounce.ViewLayer
{
    // TODO
    // This script is going to be changed, Created it for urgent requirement of Audio
    public class GameAudioView : BaseView
    {
        #region Variables

        [Header("Audio Sources")]
        [SerializeField] private AudioSource _audioSourceBGMusic;
        [SerializeField] private AudioSource _audioSourceSound;

        [Header("Audio Data")]
        [SerializeField] private AudioManagerData _audioManagerData;

        public AudioManagerData AudioManagerData => _audioManagerData;

        private GameAudioMediator _mediator;
        private static GameAudioView _instance;

        #endregion

        #region UnityMethods

      
        private void Start()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            Assertion();
            Initialize(); 
            _mediator.Start();
        }

        private void OnDestroy()
        {
            _mediator = null;
        }

        #endregion

        #region Initialization

        private void Initialize()
        {
            _mediator = new(this);
        }

        #endregion

        #region Assertion

        private void Assertion()
        {
            Assert.IsNotNull(_audioSourceBGMusic, "Please Provide AudioSourceBGMusic.");
            Assert.IsNotNull(_audioSourceSound, "Please Provide AudioSourceVoiceOver.");
            Assert.IsNotNull(_audioManagerData, "Please Provide AudioManagerData.");
        }

        #endregion

        #region PlayBGMusic

        public void StartPlayBGMusic(float volumeRange, AudioClip audioClip )
        {
            _audioSourceBGMusic.volume = volumeRange;
            if (_audioSourceBGMusic.clip != audioClip)
            {
                _audioSourceBGMusic.clip = audioClip;
                _audioSourceBGMusic.Play();
            }
        }

        public void ChangeBGMusicVolume(float volumeRange)
        {
            _audioSourceBGMusic.volume = volumeRange;
           Debug.Log( "volumeRange" + volumeRange);

        }

        #endregion

        #region PlayAudioClip

        public void PlayAudioClip(AudioClip audioClip)
        {

            if (_audioSourceSound.isPlaying)
                {
                    _audioSourceSound.Stop();
                }

                _audioSourceSound.clip = audioClip; 
                _audioSourceSound.Play();
           
        }

        public void StopSounds()
        {
           _audioSourceSound?.Stop();
        }

        internal void StopMusic()
        {
            _audioSourceBGMusic?.Stop();
        }

        #endregion

    }
}
