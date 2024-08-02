using System;
using System.Collections.Generic;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem
{
    public class Inventory : IInventory
    {
        public event Action InventoryChanged;

        private readonly List<InventorySlot> _slots;

        public IEnumerable<InventorySlot> InventorySlots => _slots;

        public Inventory()
        {
            _slots = new();
        }

        public bool TryAdd(Item itemtoAdd, int count = 1)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (itemtoAdd.ID == slot.Item.ID)
                {
                    if(slot.TryIncreaseCount(count))
                    {
                        Debug.Log("Item added, ID:  " + slot.Item.ID + " quantity: " + slot.Quantity);
                        InventoryChanged?.Invoke();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            _slots.Add(new InventorySlot(itemtoAdd, count));
            return true;
        }

        public bool TryRemove(Item itemToRemove, int count = 1)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (itemToRemove.ID == slot.Item.ID)
                {
                    if (count > slot.Quantity)
                        return false;

                    if(slot.TryDecreaseCount(count))
                    {
                        Debug.Log("Item removed, ID:  " + slot.Item.ID + " current quantity: " + slot.Quantity);
                        InventoryChanged?.Invoke();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public InventorySlot GetItemSlot(Item itemToFind)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (itemToFind.ID == slot.Item.ID)
                    return slot;
            }

            return null;
        }

        public void Dispose()
        {
            _slots.Clear();
        }
    }
}