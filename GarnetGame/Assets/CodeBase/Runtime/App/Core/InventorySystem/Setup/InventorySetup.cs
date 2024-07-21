using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem.Setup
{
    public class InventorySetup : MonoBehaviour
    {
        [SerializeField] private InventorySetupData _inventorySetupData;
        private IInventory _inventory;

        [Inject]
        public void Construct(IInventory inventory)
        {
            _inventory = inventory;

            foreach (var item in _inventorySetupData.ItemsToSetup)
            {
                _inventory.TryAdd(item, 0);
            }
        }
    }
}
