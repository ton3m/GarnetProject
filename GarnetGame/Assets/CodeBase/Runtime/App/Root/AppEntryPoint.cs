using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad;
using GarnnetProject.Assets.CodeBase.Runtime.Root;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Root
{
    public class AppEntryPoint : MonoBehaviour
    {
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
