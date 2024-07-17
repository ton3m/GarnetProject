using System.Collections;
using System.Collections.Generic;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using UnityEngine;
using PrimeTween;
using System.Threading.Tasks;

namespace GarnnetProject
{
    public class CaveRunner : MonoBehaviour
    {
        [SerializeField] private Layer _layerPrefab;
        [SerializeField] private Transform _layerParent;
        [SerializeField] private Transform _startLayerPoisition;
        [SerializeField] private Transform _layerMoveEndPoisition;
        [SerializeField] private float _moveDuration = 0.2f;
        private Layer _currentLayer;
        private LayerPool _pool;
        private LayerGenerator _generator;
        private bool _isMoveLayerEnable;
        private bool _isInited;

        [ContextMenu("Begin")]
        public void Begin()
        {
            _generator = new LayerGenerator();
            Layer[] layerObjects = _generator.Create(_layerPrefab, 4, _layerParent);

            foreach (var layer in layerObjects)
            {
                layer.LayerDestroyed += OnLayerDestroyed;
            }

            _pool = new LayerPool(layerObjects);

            _isMoveLayerEnable = true;
            _isInited = true;
            MoveNewCurrentLayer();
        }

        public void Init()
        {
            // show loading screen
            //
            // generate layers for pool
            //      subscribe for destroy event += LeyerDestroyed()
            //
            // set first layer
            // set right coords
            // 
            // hide loading screen

            if(!_isInited)
                Begin();

            // hide loading curtain
        }

        public void OnLayerDestroyed()
        {
            // play destroy animation
            // pool back the layer
            // ....
            // show choice to move forward and spend one more railroad
            //   remove one railroad from inventory
            // set next layer in distance step
            // play move forward animation in one step

            _currentLayer.gameObject.SetActive(false);
            _currentLayer = null;
            _isMoveLayerEnable = true;
        }
    
        private void SetStartPosition()
        {
            _currentLayer.transform.position = _startLayerPoisition.position;
            _currentLayer.gameObject.SetActive(true);
        }

        public void MoveNewCurrentLayer()
        {
            if(_currentLayer != null)
                return;

            if(!_isMoveLayerEnable)
                return;

            _isMoveLayerEnable = false;
            _currentLayer = _pool.GetPool();
            SetStartPosition();

            // tween animation to move layer
            StartCoroutine(MoveLayerToPlayer());
            // Tween.PositionZ(_currentLayer.transform, endValue: _layerMoveEndPoisition.position.z, duration: _moveDuration)
            //     .OnComplete(() => _currentLayer.Init());
        }

        private IEnumerator MoveLayerToPlayer()
        {
            yield return Tween.PositionZ(_currentLayer.transform, endValue: _layerMoveEndPoisition.position.z, duration: _moveDuration)
                .ToYieldInstruction();

            // .OnComplete(() => _currentLayer.Init();
            _currentLayer.Init();
            
            // while(_currentLayer.transform.position.z != _layerMoveEndPoisition.position.z)
            // {
            //     _currentLayer.transform.position = new Vector3(
            //         _currentLayer.transform.position.x, 
            //         _currentLayer.transform.position.y, 
            //         _currentLayer.transform.position.z - 1f);
            //         yield return new WaitForSeconds(_strengthMove);
            // }
            //_currentLayer.Init();
        }
    }
}
