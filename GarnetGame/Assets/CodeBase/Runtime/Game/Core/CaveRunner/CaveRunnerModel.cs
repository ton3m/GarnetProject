using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;
using Random = UnityEngine.Random;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveRunnerModel
    {
        private readonly GlobalCaveSettings _config;
        private ObjectPool<Layer> _layerPool;
        private LayerBuilder _builder;

        public CaveRunnerModel(GlobalCaveSettings globalCaveSettings, ObjectPool<Layer> layerPool)
        {
            _config = globalCaveSettings;
            _layerPool = layerPool;

            CreateLayerBuilder();
        }

        public Layer GetLayer()
        {
            Layer layer = _layerPool.GetPool();
            
            return _builder.BuildLayer(layer, 
                    _config.LayerMaterialContexts[Random.Range(0, _config.LayerMaterialContexts.Length)]);
        }

        public void ReturnLayerToPool(Layer layer)
        {
            _layerPool.ReturnPool(layer);
        }

        private void CreateLayerBuilder()
        {
            _builder = new LayerBuilder();
        }
    }
}
