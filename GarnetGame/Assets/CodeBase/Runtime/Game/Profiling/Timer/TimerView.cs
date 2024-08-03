using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private ProfilingRecorderUi _ui;
        [SerializeField] private float _updateDelay = 0.25f;

        private Timer _timer;

        public void Construct(Timer timer)
        {
            _timer = timer;
            
            OnDisable();
            OnEnable();
        }

        private void Awake() => _timer ??= new Timer();

        private void Start() => StartCoroutine(UpdateView());

        private void OnEnable()
        {
            _ui.StartRecBtn.onClick.AddListener(_timer.Start);
            _ui.StopRecBtn.onClick.AddListener(_timer.Stop);
            _ui.DeleteRecBtn.onClick.AddListener(_timer.Reset);
            _ui.SaveRecBtn.onClick.AddListener(_timer.Stop);
        }

        private void OnDisable()
        {
            _ui.StartRecBtn.onClick.RemoveListener(_timer.Start);
            _ui.StopRecBtn.onClick.RemoveListener(_timer.Stop);
            _ui.DeleteRecBtn.onClick.RemoveListener(_timer.Reset);
            _ui.SaveRecBtn.onClick.RemoveListener(_timer.Stop);
        }

        private IEnumerator UpdateView()
        {
            WaitForSeconds delay = new(_updateDelay);

            while (gameObject.activeSelf)
            {
                UpdateText();
                yield return delay;
            }
        }

        private void UpdateText() => 
            _ui.UpdateTime(_timer.RecTime);
    }
}