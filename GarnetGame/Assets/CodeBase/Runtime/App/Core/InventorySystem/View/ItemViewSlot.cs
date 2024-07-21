using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.InventorySystem.View
{
    public class ItemViewSlot : MonoBehaviour
    {
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public TMP_Text TextCount { get; private set; }
    }
}