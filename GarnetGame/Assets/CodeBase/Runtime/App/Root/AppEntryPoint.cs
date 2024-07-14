using GarnnetProject.Assets.CodeBase.Runtime.Root;
using System;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Root
{
    public class AppEntryPoint : MonoBehaviour
    {
        public event Action GoToGameplaySceneRequested;

        [SerializeField] private UIAppRootView _sceneUIRootPrefab;

        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToGameplayButtonClicked += () =>
            {
                GoToGameplaySceneRequested?.Invoke();
            };
        }
    }
}
