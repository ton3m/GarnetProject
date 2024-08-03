using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Profiling
{
    public class ProfilingSaver
    {
        public void SaveData(
            string recordPath,
            DevicePerformanceData performanceData,
            FramerRateData framerateData,
            TimerData timerData)
        {
            string file1 = JsonConvert.SerializeObject(performanceData);
            string file2 = JsonConvert.SerializeObject(framerateData);
            string file3 = JsonConvert.SerializeObject(timerData);

            DownloadProfilingData(recordPath);
            DownloadAdditiveFiles(new List<string> {file1, file2, file3 });
        }

        public void DownloadProfilingData(string path)
        {
            string file = Convert.ToBase64String(File.ReadAllBytes(path));
            string functionName = "DownloadProfilingData";

            Application.ExternalCall(functionName, file);
        }

        public void DownloadAdditiveFiles(List<string> jsonFiles)
        {
            string file = JsonConvert.SerializeObject(jsonFiles);
            string functionName = "DownloadAdditiveData";

            Application.ExternalCall(functionName, file);
        }
    }
}