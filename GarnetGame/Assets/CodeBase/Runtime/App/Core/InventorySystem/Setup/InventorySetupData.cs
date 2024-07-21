using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem.Setup
{
    [CreateAssetMenu(fileName = "Inventory Setup Data")]
    public class InventorySetupData : ScriptableObject
    {
        [field: SerializeField] public Item[] ItemsToSetup { get; private set; }
    }
}
