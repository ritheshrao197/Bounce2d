using UnityEngine;

namespace Bounce.DataModel
{
    [System.Serializable]
    public class SFX 
    {
        [SerializeField]
        public SFXType clipType;
        [SerializeField]
        public AudioClip clip;
    }
    
}