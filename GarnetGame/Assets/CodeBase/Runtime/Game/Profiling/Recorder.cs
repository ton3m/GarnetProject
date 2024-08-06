using UnityEngine;

namespace CodeBase.Profiling
{
    public class Recorder
    {
        public bool HasRecord { get; private set; }
        public bool IsRecording { get; private set; }

        public void Start()
        {
            if (IsRecording) return;
            //Debug.Log("REC Started");

            IsRecording = true;
            
            if (HasRecord)
            {
                OnContinue();
            }
            else
            {
                HasRecord = true;
                OnStart();
            }
        }

        public void Stop()
        {
            if (!IsRecording) return;
            //Debug.Log("REC Stopped");

            IsRecording = false;

            OnStop();
        }

        public void Reset()
        {
            Stop();
            HasRecord = false;

            OnReset();
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnContinue()
        {
            OnStart();
        }

        protected virtual void OnStop()
        {
        }

        protected virtual void OnReset()
        {
        }
    }
}