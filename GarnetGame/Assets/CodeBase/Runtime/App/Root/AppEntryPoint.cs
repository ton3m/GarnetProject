using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using GarnnetProject.Assets.CodeBase.Runtime.Root;
using System;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Root
{
    public class AppEntryPoint : MonoBehaviour
    {
        public event Action GoToGameplaySceneRequested;

        [SerializeField] private UIAppRootView _sceneUIRootPrefab;

        [Inject]
        public void Run(UIRootView uiRoot, ISceneLoader sceneLoader)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToGameplayButtonClicked += () =>
            {
                sceneLoader.LoadScene(Scenes.GAME);
            };
        }
    }
}
