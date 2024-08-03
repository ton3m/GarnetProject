using System;
using System.Collections.Generic;

namespace CodeBase.Profiling
{
    [Serializable]
    public class TimerData
    {
        public TimeSpan RecTime { get; private set; }
        
        public List<DateTime> StartPoints => new(_startPoints);
        public List<DateTime> StopPoints => new(_stopPoints);
        
        private readonly List<DateTime> _startPoints;
        private readonly List<DateTime> _stopPoints;
        
        public TimerData(List<DateTime> startPoints, List<DateTime> stopPoints, TimeSpan recTime)
        {
            _startPoints = new List<DateTime>(startPoints);
            _stopPoints = new List<DateTime>(stopPoints);
            RecTime = recTime;
        }
    }
    
    public class TimePoints
    {
        public readonly List<DateTime> StartPoints = new();
        public readonly List<DateTime> StopPoints = new();
        
        public void Clear()
        {
            StartPoints.Clear();    
            StopPoints.Clear();    
        }
        
        public void AddStartPoint(DateTime point) => StartPoints.Add(point);

        public void AddStopPoint(DateTime point) => StopPoints.Add(point);
    }
}