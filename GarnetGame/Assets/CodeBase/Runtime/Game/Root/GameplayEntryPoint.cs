using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using GarnnetProject.Assets.CodeBase.Runtime.Root;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootView _sceneUIRootPrefab;
        [SerializeField] private CaveBootstrap _caveRunner;

        [Inject]
        public void Run(UIRootView uiRoot, ISceneLoader sceneLoader)
        {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainAppButtonClicked += () =>
            {
                sceneLoader.LoadScene(Scenes.MAIN_APP);
            };

            _caveRunner.InitCave();
            uiRoot.HideLoadingCurtain();
        }
    }
}
