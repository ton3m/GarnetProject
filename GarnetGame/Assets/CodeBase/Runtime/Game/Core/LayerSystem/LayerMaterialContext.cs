using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem
{
    public struct LayerMaterialContext
    {
        public Color MaterialColor;

        public LayerMaterialContext(Color materialColor)
        {
            MaterialColor = materialColor;
        }
    }
}
