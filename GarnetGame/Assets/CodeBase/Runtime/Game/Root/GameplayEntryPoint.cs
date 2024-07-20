using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using GarnnetProject.Assets.CodeBase.Runtime.Root;
using System;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMainAppSceneRequested;
        
        [SerializeField] private UIGameplayRootView _sceneUIRootPrefab;
        [SerializeField] private CaveRunner _caveRunner;

        [Inject]
        public void Run(UIRootView uiRoot, ISceneLoader sceneLoader)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainAppButtonClicked += () =>
            {
                sceneLoader.LoadScene(Scenes.MAIN_APP);
            };

            _caveRunner.Begin();
            uiRoot.HideLoadingCurtain();
        }
    }
}
