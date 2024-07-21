using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Core.PlayerConfigration
{
    [CreateAssetMenu(fileName = "Player Default Config")]
    public class PlayerDefaultConfig : ScriptableObject
    {
        [field: SerializeField] public PlayerConfigState State { get; private set; }
    }
}
