using System;
using UnityEngine;

namespace GarnnetProject
{
    public class UIGameplayRootView : MonoBehaviour
    {
        public event Action GoToMainAppButtonClicked;

        public void HandleGoToMainAppButtonClick()
        {
            GoToMainAppButtonClicked?.Invoke();
        }
    }
}
