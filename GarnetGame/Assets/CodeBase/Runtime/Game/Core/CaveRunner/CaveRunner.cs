using System.Collections;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using UnityEngine;
using PrimeTween;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveRunner : MonoBehaviour
    {
        [SerializeField] private Layer _layerPrefab;
        [SerializeField] private Transform _layerParent;
        [SerializeField] private Transform _startLayerPoisition;
        [SerializeField] private Transform _layerMoveEndPoisition;
        [SerializeField] private float _moveDuration = 0.2f;
        private Layer _currentLayer;
        private ObjectPool<Layer> _pool;
        private LayerGenerator _generator;
        private bool _isInited;

        public void Begin()
        {
            if (!_isInited)
                Init();
        }

        private void Init() // set with loading curtain
        {
            _generator = new LayerGenerator();
            Layer[] layerObjects = _generator.Create(_layerPrefab, 4, _layerParent);

            foreach (var layer in layerObjects)
            {
                layer.LayerDestroyed += OnLayerDestroyed;
            }

            _pool = new ObjectPool<Layer>(layerObjects);
            _isInited = true;

            SetNewCurrentLayer();
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

            yield return Tween.PositionZ(_currentLayer.transform, endValue: _layerMoveEndPoisition.position.z, duration: _moveDuration)
                .ToYieldInstruction();

            _currentLayer.Init();
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
            if (!_isInited || _currentLayer != null)
                return false;

            return  true;
        }

        private void SetUpNewCurrentLayer()
        {
            _currentLayer.transform.position = _startLayerPoisition.position;
            _currentLayer.SetUpMaterial(new LayerMaterialContext(RandomColorGenerator()));
            _currentLayer.gameObject.SetActive(true);
        }

        private Color RandomColorGenerator()
        {
            return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
