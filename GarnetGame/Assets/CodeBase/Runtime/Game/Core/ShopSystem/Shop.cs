using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem;
using UnityEngine;
using VContainer;

namespace GarnnetProject
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Item _firstItemData;
        [SerializeField] private Item _secondItemData;

        private IInventory _inventory;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _inventory = inventory;
        }

        public void IncreaseFirstItem()
        {
            _inventory.TryAdd(_firstItemData);
        }
    
        public void IncreaseSecondItem()
        {
            _inventory.TryAdd(_secondItemData);
        }

        public void DecreaseCountOnFirstItem()
        {
            _inventory.TryRemove(_firstItemData);
        }

        public void DecreaseCountOnSecondItem()
        {
            _inventory.TryRemove(_secondItemData);
        }
    }
}
