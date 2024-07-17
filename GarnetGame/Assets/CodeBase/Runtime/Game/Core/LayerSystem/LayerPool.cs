using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarnnetProject
{
    public class LayerPool
    {
        private List<Layer> _layers;

        // public LayerPool(Layer prefabToPool, int poolSize, Transform parent = null)
        // {
        //     _layers = new List<Layer>(poolSize);

        //     for (int i = 0; i < poolSize; i++)
        //     {
        //         Layer layerObject = GameObject.Instantiate(prefabToPool, Vector3.zero, Quaternion.identity, parent);
        //         layerObject.gameObject.SetActive(false);
        //         _layers.Add(layerObject);
        //     }
        // }

        public LayerPool(Layer[] layers)
        {
            _layers = layers.ToList();
        }

        public Layer GetPool()
        {
            for (int i = 0; i < _layers.Count; i++)
            {
                if(!_layers[i].isActiveAndEnabled)
                {
                    return _layers[i];
                }
            }

            throw new ArgumentOutOfRangeException("Out of Pool!");
        }
    }
}
