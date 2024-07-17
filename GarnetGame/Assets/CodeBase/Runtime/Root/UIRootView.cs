using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.LoadingCurtainService;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private Transform _uiSceneContainer;

        private void Awake()
        {
            HideLoadingCurtain();
        }

        public void ShowLoadingCurtain()
        {
            _loadingCurtain.Show();
        }
    
        public void HideLoadingCurtain()
        {
            _loadingCurtain.Hide();
        }

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI();
            
            sceneUI.transform.SetParent(_uiSceneContainer, false);
        }

        private void ClearSceneUI()
        {
            var childCount = _uiSceneContainer.childCount;
            for (var i = 0; i < childCount; i++)
            {
                Destroy(_uiSceneContainer.GetChild(i).gameObject);
            }
        }
    }
}
