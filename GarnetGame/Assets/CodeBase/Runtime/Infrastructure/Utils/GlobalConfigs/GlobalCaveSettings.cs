using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs
{
    [CreateAssetMenu(fileName = "Global Cave Settings")]
    public class GlobalCaveSettings : ScriptableObject
    {
        [field: SerializeField] public Layer BaseLayerPrefab { get; private set; }
        [field: SerializeField, Min(0.05f)] public float LayerMoveDuration { get; private set; } = 0.2f;
        [field: SerializeField] public LayerMaterialContext[] LayerMaterialContexts { get; private set; }
    }
}
