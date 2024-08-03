using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class ProfilingRecorderView : MonoBehaviour
    {
        public event Action Saving;

        [SerializeField] private ProfilingRecorderUi _ui;
        [SerializeField] private float _updateDelay = 1;

        private ProfilingRecorder _recorder;

        public void Construct(ProfilingRecorder recorder)
        {
            _recorder = recorder;

            OnDisable();
            OnEnable();
        }

        private void Awake() => _recorder ??= new ProfilingRecorder();

        private void Start() => StartCoroutine(UpdateView());

        private void OnEnable()
        {
            _ui.StartRecBtn.onClick.AddListener(_recorder.Start);
            _ui.StopRecBtn.onClick.AddListener(_recorder.Stop);
            _ui.DeleteRecBtn.onClick.AddListener(_recorder.Reset);
            _ui.SaveRecBtn.onClick.AddListener(Save);
        }

        private void OnDisable()
        {
            _ui.StartRecBtn.onClick.RemoveListener(_recorder.Start);
            _ui.StopRecBtn.onClick.RemoveListener(_recorder.Stop);
            _ui.DeleteRecBtn.onClick.RemoveListener(_recorder.Reset);
            _ui.SaveRecBtn.onClick.RemoveListener(Save);
        }

        private IEnumerator UpdateView()
        {
            WaitForSeconds delay = new(_updateDelay);

            while (gameObject.activeSelf)
            {
                _ui.UpdateSize(_recorder.RecSizeMb);
                yield return delay;
            }
        }

        private void Save()
        {
            if (_recorder.HasRecord == false) return;

            _recorder.Stop();
            Saving?.Invoke();
        }
    }
}