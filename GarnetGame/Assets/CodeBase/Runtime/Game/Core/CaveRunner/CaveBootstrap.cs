using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.OreSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Factory;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;
using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveBootstrap : MonoBehaviour
    {
        [SerializeField] private CaveRunnerView _view;
        private GlobalCaveSettings _config;

        [Inject]
        private void Costruct(GlobalCaveSettings globalCaveSettings)
        {
            _config = globalCaveSettings;
        }

        public void InitCave()
        {
            ObjectFactory factory = new ObjectFactory();

            var model = new CaveRunnerModel(_config, 
                CreateLayerPool(factory, _view.transform), CreateOrePool(factory, _view.transform));

            _view.Init(model, _config);
        }

        private ObjectPool<Layer> CreateLayerPool(ObjectFactory factory, Transform layerParent)
        {
            Layer[] layerObjects = factory.Create(_config.BaseLayerPrefab, 4, layerParent);
            return new ObjectPool<Layer>(layerObjects);
        }

        private ObjectPool<Ore> CreateOrePool(ObjectFactory factory, Transform oreParent)
        {
            Ore[] oreObjects = factory.Create(_config.BaseOrePrefab, 4, oreParent);
            return new ObjectPool<Ore>(oreObjects);
        }

    }
}
