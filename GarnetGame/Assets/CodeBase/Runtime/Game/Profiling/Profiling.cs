using UnityEngine;

namespace CodeBase.Profiling
{
    public class Profiling : MonoBehaviour
    {
        [SerializeField] private FrameRater _frameRaterMb;

        [Header("Views")]
        [SerializeField] private ProfilingRecorderView _recorderView;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private FrameraterView _frameraterView;
        
        private ProfilingSaver _saver;
        
        private ProfilingRecorder _recorder;
        private Timer _timer;
        private IFrameRater _frameRater;
        private DevicePerformanceProvider _perfProvider;

        private void Awake()
        {
            _saver = new ProfilingSaver();
            
            _recorder = new ProfilingRecorder();
            _timer = new Timer();
            _frameRater = _frameRaterMb;
            _perfProvider = new DevicePerformanceProvider();

            _recorderView.Construct(_recorder);
            _timerView.Construct(_timer);
            _frameraterView.Construct(_frameRater);
        }

        private void OnEnable() => _recorderView.Saving += Save;

        private void OnDisable() => _recorderView.Saving -= Save;

        private void Save()
        {
            Debug.Log("SAVING ALL");
            
            _recorder.Stop();
            _timer.Stop();
            
            var performanceData = _perfProvider.GetData();
            var framerateData = _frameRater.GetData();
            var timerData = _timer.GetData();

            _saver.SaveData(_recorder.RecFullPath, performanceData, framerateData, timerData);
            
            _recorder.Reset();
            _timer.Reset();
        }
    }
}