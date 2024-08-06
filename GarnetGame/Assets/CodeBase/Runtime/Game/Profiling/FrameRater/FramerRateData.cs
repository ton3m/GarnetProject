namespace CodeBase.Profiling
{
    [System.Serializable]
    public class FramerRateData
    {
        public float AvgFps { get; private set; }
        public float HighestFps { get; private set; }
        public float LowestFps { get; private set; }

        public FramerRateData(float avgFps, float highestFps, float lowestFps)
        {
            AvgFps = avgFps;
            HighestFps = highestFps;
            LowestFps = lowestFps;
        }
    }
}