using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem
{
    public class LayerBuilder
    {
        public LayerBuilder()
        {
            
        }

        public Layer BuildLayer(Layer layer, LayerMaterialContext context)
        {
            layer.SetUp(context);
            return layer; // временно
        }
    }
}
