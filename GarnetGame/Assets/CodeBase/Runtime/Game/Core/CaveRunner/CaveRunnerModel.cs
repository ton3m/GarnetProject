using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.OreSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveRunnerModel
    {
        private readonly GlobalCaveSettings _config;
        private ObjectPool<Layer> _layerPool;
        private ObjectPool<Ore> _orePool;
        private LayerBuilder _builder;

        public CaveRunnerModel(GlobalCaveSettings globalCaveSettings, ObjectPool<Layer> layerPool, ObjectPool<Ore> orePool)
        {
            _config = globalCaveSettings;
            _layerPool = layerPool;
            _orePool = orePool;

            CreateLayerBuilder();
        }

        public Layer GetLayer()
        {
            Layer layer = _layerPool.GetPool();
            return BuildLayerWithMaterial(layer, _config.layerMaterialContexts[Random.Range(0, _config.layerMaterialContexts.Length)]);
        }

        public void ReturnLayerToPool(Layer layer)
        {
            _layerPool.ReturnPool(layer);
        }

        private Layer BuildLayerWithMaterial(Layer layer, LayerMaterialContext layerMaterialContext)
        {
            return _builder.BuildLayer(layer, layerMaterialContext);
        }
        

        private void CreateLayerBuilder()
        {
            _builder = new LayerBuilder();
        }
    }
}
