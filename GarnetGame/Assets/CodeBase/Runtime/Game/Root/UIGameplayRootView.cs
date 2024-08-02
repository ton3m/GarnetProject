using System;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game
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
