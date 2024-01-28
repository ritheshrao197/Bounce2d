using System.Collections.Generic;
using UnityEngine;
namespace Bounce
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level/Level Data")]
    public class LevelData : ScriptableObject
    {
        public List<GameObject> LevelGameObjects = new List<GameObject>();

        // Optional method to add game objects directly from the Inspector
        public void AddGameObject(GameObject gameObject)
        {
            LevelGameObjects.Add(gameObject);
        }
    }


}
