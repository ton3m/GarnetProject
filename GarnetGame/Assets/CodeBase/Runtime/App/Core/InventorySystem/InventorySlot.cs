using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem
{
    public class InventorySlot
    {
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
        }

        public int MaxQuantity => Item.MaxQuantity;

        public Item Item { get; }

        public InventorySlot(Item item, int startQuantity = 1)
        {
            Item = item;

            if(startQuantity > 0)
                _quantity = startQuantity;
            else
                _quantity = 0;
        }

        public bool TryIncreaseCount(int count)
        {
            return TryUpdateQuantity(Quantity + count);
        }

        public bool TryDecreaseCount(int count)
        {
            return TryUpdateQuantity(Quantity - count);
        }

        private bool TryUpdateQuantity(int value)
        {
            if (value < 0)
                return false;

            int clampedValue = Mathf.Clamp(value, 0, MaxQuantity);

            if (clampedValue != _quantity)
            {
                _quantity = clampedValue;
                return true;
            }
            else
                return false;
        }
    }
}