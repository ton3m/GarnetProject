namespace CodeBase.Profiling
{
    [System.Serializable]
    public class DevicePerformanceData
    {
        public int i = 5;
        public string DeviceModel { get; }
        public string DeviceName { get; }
        public string OperatingSystem { get; }
        public int SystemMemorySize { get; }
        public string ProcessorType { get; }
        public int ProcessorCount { get; }
        public int ProcessorFrequency { get; }
        public string GraphicsDeviceName { get; }
        public string GraphicsDeviceVendor { get; }
        public string GraphicsDeviceVersion { get; }
        public int GraphicsMemorySize { get; }
        public int GraphicsShaderLevel { get; }
        public bool SupportsComputeShaders { get; }

        public DevicePerformanceData(
            string deviceModel,
            string deviceName,
            string operatingSystem,
            int systemMemorySize,
            string processorType,
            int processorCount,
            int processorFrequency,
            string graphicsDeviceName,
            string graphicsDeviceVendor,
            string graphicsDeviceVersion,
            int graphicsMemorySize,
            int graphicsShaderLevel,
            bool supportsComputeShaders)
        {
            DeviceModel = deviceModel;
            DeviceName = deviceName;
            OperatingSystem = operatingSystem;
            SystemMemorySize = systemMemorySize;
            ProcessorType = processorType;
            ProcessorCount = processorCount;
            ProcessorFrequency = processorFrequency;
            GraphicsDeviceName = graphicsDeviceName;
            GraphicsDeviceVendor = graphicsDeviceVendor;
            GraphicsDeviceVersion = graphicsDeviceVersion;
            GraphicsMemorySize = graphicsMemorySize;
            GraphicsShaderLevel = graphicsShaderLevel;
            SupportsComputeShaders = supportsComputeShaders;
        }
    }
}