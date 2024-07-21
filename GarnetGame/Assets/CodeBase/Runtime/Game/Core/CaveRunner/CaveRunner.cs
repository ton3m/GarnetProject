using System.Collections;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using UnityEngine;
using PrimeTween;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using VContainer;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveRunner : MonoBehaviour
    {
        [SerializeField] private Layer _layerPrefab;
        [SerializeField] private Transform _layerParent;
        [SerializeField] private Transform _startLayerPoisition;
        [SerializeField] private Transform _layerMoveEndPoisition;
        private GlobalCaveSettings _config;
        private ObjectPool<Layer> _pool;
        private Layer _currentLayer;
        private bool _isPoolInited;

        [Inject]
        private void Costruct(GlobalCaveSettings globalCaveSettings)
        {
            _config = globalCaveSettings;
        }

        public void Begin()
        {
            if (!_isPoolInited)
            {
                CreateLayerPool();
                _isPoolInited = true;

                SetNewCurrentLayer();
            }
        }

        public void SetNewCurrentLayer()
        {
            if(!IsCapableToSetNewCurrentLayer())
                return;

            _currentLayer = _pool.GetPool();

            StartCoroutine(MoveCurrentLayerToPlayer());
        }

        private IEnumerator MoveCurrentLayerToPlayer()
        {
            SetUpNewCurrentLayer();

            yield return Tween.PositionZ(_currentLayer.transform, endValue: _layerMoveEndPoisition.position.z, duration: _config.LayerMoveDuration)
                .ToYieldInstruction();

            _currentLayer.Init();
        }

        private void CreateLayerPool()
        {
            LayerGenerator generator = new LayerGenerator();
            Layer[] layerObjects = generator.Create(_layerPrefab, 4, _layerParent);

            foreach (var layer in layerObjects)
            {
                layer.LayerDestroyed += OnLayerDestroyed;
            }

            _pool = new ObjectPool<Layer>(layerObjects);
        }

        public void OnLayerDestroyed()
        {
            //play destroy animation

            _pool.ReturnPool(_currentLayer);
            _currentLayer = null;

            SetNewCurrentLayer(); // cyclic
        }

        private bool IsCapableToSetNewCurrentLayer()
        {
            if (!_isPoolInited || _currentLayer != null)
                return false;

            return  true;
        }

        private void SetUpNewCurrentLayer()
        {
            _currentLayer.transform.position = _startLayerPoisition.position;
            _currentLayer.SetUp(GetLayerMaterial());
            _currentLayer.gameObject.SetActive(true);
        }

        private LayerMaterialContext GetLayerMaterial()
        {
            //Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)

            var t = _config.layerMaterialContexts[Random.Range(0, _config.layerMaterialContexts.Length)];
            return t;
        }
    }
}
