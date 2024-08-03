using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Profiling
{
    public class ProfilingRecorderUi : MonoBehaviour
    {
        [field: Header("Recording")]
        [field: SerializeField] public Button StartRecBtn { get; private set; }
        [field: SerializeField] public Button StopRecBtn { get; private set; }

        [field: Header("Monitor")]
        [field: SerializeField] public TMP_Text RecordTime { get; private set; }
        [field: SerializeField] public TMP_Text RecordSize { get; private set; }

        [field: Header("Saving")]
        [field: SerializeField] public Button SaveRecBtn { get; private set; }
        [field: SerializeField] public Button DeleteRecBtn { get; private set; }
        
        public void UpdateSize(float recSizeMb)
        {
            RecordSize.text = $"{recSizeMb:0.0} Mb";
        }

        public void UpdateTime(TimeSpan recTime)
        {
            RecordTime.text = $"{recTime:mm\\:ss}";
        }
    }
}