using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bounce.DataModel
{
    [CreateAssetMenu(fileName = "AudioManagerData", menuName = "Audio/AudioManagerData")]
    public class AudioManagerData : ScriptableObject
    {
        [SerializeField]
        public SFX[] sFXes;
        [SerializeField]
        public AudioClip[] bGMs;
        public AudioClip GetAudioClipByType(SFXType type)
        {
            return sFXes.FirstOrDefault(x => x.clipType == type)?.clip;
        }
        

    }

}