using GarnnetProject.Assets.CodeBase.Runtime.Root;
using System;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMainAppSceneRequested;
        
        [SerializeField] private UIGameplayRootView _sceneUIRootPrefab;

        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainAppButtonClicked += () =>
            {
                GoToMainAppSceneRequested?.Invoke();
            };
        }
    }
}
