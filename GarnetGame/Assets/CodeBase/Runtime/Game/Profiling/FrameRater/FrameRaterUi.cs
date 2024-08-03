using TMPro;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class FrameRaterUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fps;
        [SerializeField] private TMP_Text _fpsAvg;

        public void SetData(float fps, float fpsAvg)
        {
            _fps.text = $"FPS: {fps:0.0}";
            _fpsAvg.text = $"AVG: {fpsAvg:0.0}";
        }
    }
}