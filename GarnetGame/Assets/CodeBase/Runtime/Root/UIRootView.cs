using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingCurtain;
        [SerializeField] private Transform _uiSceneContainer;

        private void Awake()
        {
            HideLoadingCurtain();
        }

        public void ShowLoadingCurtain()
        {
            _loadingCurtain.SetActive(true);
        }
    
        public void HideLoadingCurtain()
        {
            _loadingCurtain.SetActive(false);
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
