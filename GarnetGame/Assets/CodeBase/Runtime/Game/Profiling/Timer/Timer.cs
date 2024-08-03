using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class Timer : Recorder
    {
        private DateTime _startTime;
        private DateTime _stopTime;

        private TimeSpan _recFragmentsTime;
        private TimeSpan _recFragmentTime => _stopTime - _startTime;

        private TimePoints _timePoints = new();
        
        public TimeSpan RecTime
        {
            get
            {
                if (IsRecording)
                    return _recFragmentsTime + (DateTime.Now - _startTime);

                return HasRecord ? _recFragmentsTime: TimeSpan.Zero;
            }
        }

        public TimerData GetData() => 
            new(_timePoints.StartPoints, _timePoints.StopPoints, RecTime);

        protected override void OnStart()
        {
            //Debug.Log("TIMER STARTED");
            _startTime = DateTime.Now;
            _timePoints.AddStartPoint(_startTime);
        }

        protected override void OnContinue()
        {
            //Debug.Log("TIMER CONTINUE");
            _startTime = DateTime.Now;
            _timePoints.AddStartPoint(_startTime);
        }

        protected override void OnStop()
        {
            //Debug.Log("TIMER STOPPED");
            _stopTime = DateTime.Now;
            _timePoints.AddStopPoint(_stopTime);

            _recFragmentsTime += _recFragmentTime;
        }

        protected override void OnReset()
        {
            //Debug.Log("TIMER RESET");
            _startTime = default;
            _stopTime = default;
            
            _timePoints.Clear();
            
            _recFragmentsTime = TimeSpan.Zero;
        }
    }
}