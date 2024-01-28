using UnityEngine;

namespace Bounce.DataModel
{
    [System.Serializable]
    public class BGM
    {
        [SerializeField]
        public BGMType clipType;
        [SerializeField]
        public AudioClip clip;
    }
}