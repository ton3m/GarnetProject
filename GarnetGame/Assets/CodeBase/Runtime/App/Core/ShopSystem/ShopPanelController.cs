using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem.View;
using UnityEngine;
using UnityEngine.UI;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.ShopSystem
{
    public class ShopPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private Button _openPanelButton;
        [SerializeField] private Button _closePanelButton;
        [SerializeField] private InventoryViewController _inventoryViewController;

        private void Start()
        {
            _openPanelButton.onClick.AddListener(OpenPanel);
            _closePanelButton.onClick.AddListener(ClosePanel);
        }
        
        private void OnDisable()
        {
            _openPanelButton.onClick.RemoveAllListeners();
            _closePanelButton.onClick.RemoveAllListeners();
        }


        public void OpenPanel()
        {
            _shopPanel.SetActive(true);
            _openPanelButton.gameObject.SetActive(false);
            _closePanelButton.gameObject.SetActive(true);

           _inventoryViewController.UpdateView();
        }

        public void ClosePanel()
        {
            _shopPanel.SetActive(false);
            _openPanelButton.gameObject.SetActive(true);
            _closePanelButton.gameObject.SetActive(false);
        }
    }
}
