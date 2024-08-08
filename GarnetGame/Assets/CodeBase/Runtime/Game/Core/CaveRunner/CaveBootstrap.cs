using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
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
        [SerializeField] private GlobalCaveSettings _defaultGlobalCaveSettings;
        private GlobalCaveSettings _config;

        [Inject]
        private void Costruct(GlobalCaveSettings globalCaveSettings)
        {
            _config = globalCaveSettings;
        }

        public void InitCave()
        {
            ValidateConfigData(ref _config);
            
            ObjectFactory factory = new ObjectFactory();

            var model = new CaveRunnerModel(_config, 
                CreateLayerPool(factory, _view.transform));

            _view.Init(model, _config);
        }

        private ObjectPool<Layer> CreateLayerPool(ObjectFactory factory, Transform layerParent)
        {
            Layer[] layerObjects = factory.Create(_config.BaseLayerPrefab, 4, layerParent);
            return new ObjectPool<Layer>(layerObjects);
        }

        private void ValidateConfigData(ref GlobalCaveSettings caveSettings)
        {
            if(caveSettings == null)
            {
                Debug.LogWarning("Cave Settings field is Null!");
                caveSettings = _defaultGlobalCaveSettings;
                return;
            }

            if(caveSettings.BaseLayerPrefab == null)
            {
                Debug.LogWarning("Base Prefab in Cave Settings IS NULL!");
                caveSettings = _defaultGlobalCaveSettings;
            }
            else if(caveSettings.LayerMaterialContexts.Length == 0)
            {
                Debug.LogWarning("Layer Material Contexts Count is 0!");
                caveSettings = _defaultGlobalCaveSettings;
            }
        }
    }
}
