using System.Collections;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class FrameraterView : MonoBehaviour
    {
        private IFrameRater _frameRater;

        [SerializeField] private FrameRater _frameRaterMb;
        [SerializeField] private FrameRaterUi _ui;
        [SerializeField] private float _updateDelay = 0.25f;

        public void Construct(IFrameRater frameRater)
        {
            _frameRater = frameRater;
        }

        private void Awake() => _frameRater ??= _frameRaterMb;

        private void Start() => StartCoroutine(nameof(UpdateView));

        private IEnumerator UpdateView()
        {
            WaitForSeconds delay = new(_updateDelay);

            while (gameObject.activeSelf)
            {
                _ui.SetData(_frameRater.Fps, _frameRater.AvgFps);
                yield return delay;
            }
        }
    }
}