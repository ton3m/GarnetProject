using UnityEngine;

namespace CodeBase.Profiling
{
    public class DevicePerformanceProvider 
    {
        public DevicePerformanceData GetData()
        {
            return new DevicePerformanceData(
                SystemInfo.deviceModel,
                SystemInfo.deviceName,
                SystemInfo.operatingSystem,

                SystemInfo.systemMemorySize,

                SystemInfo.processorType,
                SystemInfo.processorCount,
                SystemInfo.processorFrequency,

                SystemInfo.graphicsDeviceName,
                SystemInfo.graphicsDeviceVendor,
                SystemInfo.graphicsDeviceVersion,
                SystemInfo.graphicsMemorySize,
                SystemInfo.graphicsShaderLevel,
                SystemInfo.supportsComputeShaders);
        }
    }
}
