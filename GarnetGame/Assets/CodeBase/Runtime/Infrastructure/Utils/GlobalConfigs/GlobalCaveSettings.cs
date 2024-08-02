using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.OreSystem;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs
{
    [CreateAssetMenu(fileName = "Global Cave Settings")]
    public class GlobalCaveSettings : ScriptableObject
    {
        [field: SerializeField] public Layer BaseLayerPrefab { get; private set; }
        [field: SerializeField] public Ore BaseOrePrefab { get; private set; }
        [field: SerializeField] public float LayerMoveDuration { get; private set; } = 0.2f;
        [field: SerializeField] public LayerMaterialContext[] layerMaterialContexts { get; private set; }
    }
}
