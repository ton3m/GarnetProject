using System.Collections;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.GlobalConfigs;
using PrimeTween;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.CaveRunner
{
    public class CaveRunnerView : MonoBehaviour
    {
        [SerializeField] private Transform _layerStartPoint;
        [SerializeField] private Transform _layerEndPoint;
        private CaveRunnerModel _model;
        private GlobalCaveSettings _config;

        public void Init(CaveRunnerModel caveRunnerModel, GlobalCaveSettings globalCaveSettings)
        {
            _model = caveRunnerModel;
            _config = globalCaveSettings;

            SetNewLayer();
        }

        private void SetNewLayer()
        {
            Layer layer = _model.GetLayer();
            layer.Destroyed += OnLayerDestroyed;

            layer.transform.position = _layerStartPoint.position;
            layer.gameObject.SetActive(true);

            StartCoroutine(GetLayerToEndPoint(layer));
        }

        private void OnLayerDestroyed(Layer layer)
        {
            layer.Destroyed -= OnLayerDestroyed;
            layer.gameObject.SetActive(false);
            _model.ReturnLayerToPool(layer);

            SetNewLayer(); // временно
            // потом наверно в этом месте кидается глобальный ивент и откуда-то забирается рельса ы
        }

        private IEnumerator GetLayerToEndPoint(Layer layer)
        {
            yield return Tween.PositionZ(layer.transform, endValue: _layerEndPoint.position.z, duration: _config.LayerMoveDuration)
                .ToYieldInstruction();

            InitLayer(layer);    
        }

        private void InitLayer(Layer layer)
        {
            layer.Init();
        }
    }
}
