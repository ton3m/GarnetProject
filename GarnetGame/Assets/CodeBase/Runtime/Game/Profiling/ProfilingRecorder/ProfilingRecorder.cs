using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

namespace CodeBase.Profiling
{
    public class ProfilingRecorder : Recorder
    {
        private readonly string _path;
        private readonly string _name;

        public string RecFullPath => Path.Combine(_path, _name);

        public float RecSizeMb =>
            HasRecord ? new FileInfo(RecFullPath).Length / (1024f * 1024f) : 0;

        public ProfilingRecorder()
        {
            _path = Application.persistentDataPath;
            _name = "profilerData.data.raw";

            Profiler.logFile = RecFullPath;
            Reset();
        }

        protected override void OnStart()
        {
            Profiler.enabled = true;
            Profiler.enableBinaryLog = true;
        }

        protected override void OnStop()
        {
            //Debug.Log("Recorder stopped");

            Profiler.enabled = false;
        }

        protected override void OnContinue()
        {
            //Debug.Log("Recorder continued");

            Profiler.enabled = true;
        }

        protected override void OnReset()
        {
            //Debug.Log("Recorder reset");
            
            Profiler.enableBinaryLog = false;
            Profiler.enableBinaryLog = true;
            Profiler.enableBinaryLog = false;
        }
    }
}