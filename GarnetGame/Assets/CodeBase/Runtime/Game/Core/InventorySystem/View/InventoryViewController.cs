using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem.View
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private ItemViewSlot _itemViewSlotPrefab;
        [SerializeField] private Transform _parent;
        private IInventory _inventory;
        private IInputHandler _inputHandler;
        private bool _isInventoryActive;

        [Inject]
        public void Construct(IInventory inventory, IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inventory = inventory;
        }

        private void Start()
        {
            _inputHandler.Actions.Gameplay.InventoryPerform.performed += ctx => SetInventory();
            _inventory.InventoryChanged += UpdateView;

            _isInventoryActive = false;
            //_parent.gameObject.SetActive(_isInventoryActive);
        }

        private void OnDestroy()
        {
            _inputHandler.Actions.Gameplay.InventoryPerform.performed -= ctx => SetInventory();
            _inventory.InventoryChanged -= UpdateView;
        }

        private void SetInventory()
        {
            _isInventoryActive = !_isInventoryActive;
            _parent.gameObject.SetActive(_isInventoryActive);
        }

        private void UpdateView()
        {
            foreach (Transform child in _parent)
            {
                Destroy(child.gameObject);
            }

            foreach (var slot in _inventory.InventorySlots)
            {
                var itemViewSlot = Instantiate(_itemViewSlotPrefab, _parent);
                itemViewSlot.Icon.sprite = slot.Item.Icon;
                itemViewSlot.TextCount.text = slot.Quantity.ToString();
            }
        }
    }
}