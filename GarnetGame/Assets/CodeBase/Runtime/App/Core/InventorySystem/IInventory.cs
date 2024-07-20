using System;
using System.Collections.Generic;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.InventorySystem
{
    public interface IInventory : IDisposable
    {
        event Action InventoryChanged;
        List<InventorySlot> InventorySlots { get; }
        bool TryAdd(Item itemtoAdd, int count = 1);
        bool TryRemove(Item itemToRemove, int count = 1);
        InventorySlot GetItemSlot(Item itemToFind);
    }
}