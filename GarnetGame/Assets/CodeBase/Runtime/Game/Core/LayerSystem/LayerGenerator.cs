using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem
{
    public class LayerGenerator
    {
        public Layer[] Create(Layer prefabToPool, int poolSize, Transform parent = null)
        {
            var _layers = new Layer[poolSize];

            for (int i = 0; i < poolSize; i++)
            {
                Layer layerObject = GameObject.Instantiate(prefabToPool, Vector3.zero, Quaternion.identity, parent);
                layerObject.gameObject.SetActive(false);
                _layers[i] = layerObject;
            }

            return _layers;
        }
    }
}
