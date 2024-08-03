using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class FrameRater : MonoBehaviour, IFrameRater
    {
        public float Fps { get; private set; }
        public float AvgFps { get; private set; }

        public float HighestFps { get; private set; }
        public float LowestFps { get; private set; } = float.MaxValue;

        private float _totalFps;

        private int _framesCount;

        private void Start()
        {
            StartCoroutine(Reset());
        }

        private void Update()
        {
            Fps = 1.0f / Time.unscaledDeltaTime;

            _totalFps += Fps;
            _framesCount++;

            AvgFps = _totalFps / _framesCount;
        }

        private void LateUpdate()
        {
            if (Fps > HighestFps) HighestFps = Fps;
            if (Fps < LowestFps) LowestFps = Fps;
        }

        public FramerRateData GetData() => new(AvgFps, HighestFps, LowestFps);

        private IEnumerator Reset()
        {
            yield return new WaitForSeconds(3f);

            while (true)
            {
                HighestFps = 0;
                LowestFps = float.MaxValue;

                _totalFps = 0;
                _framesCount = 0;

                yield return new WaitForSeconds(10f);
            }
        }
    }

    public interface IFrameRater
    {
        float Fps { get; }
        float AvgFps { get; }
        float HighestFps { get; }
        float LowestFps { get; }
        FramerRateData GetData();
    }
}