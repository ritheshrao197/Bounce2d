using Bounce.MediatorLayer;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace Bounce.ViewLayer
{
    public class LevelGeneratorView : BaseView
    {
        [SerializeField] public LevelData levelData;
        [SerializeField] private GameObject levelContainer;

        private LevelGeneratorMediator mediator;

      
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            mediator = new LevelGeneratorMediator(this);
        }

        internal void InstantiateLevel(GameObject levelPrefab)
        {
            Transform[] children = levelContainer.GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                if (child != levelContainer.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            Instantiate(levelPrefab, levelContainer.transform);
        }

    }
}