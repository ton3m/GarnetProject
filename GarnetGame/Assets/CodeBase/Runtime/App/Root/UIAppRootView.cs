using System;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.App.Root
{
    public class UIAppRootView : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;

        public void HandleGoToGameplayButtonClick()
        {
            GoToGameplayButtonClicked?.Invoke();
        }
    }
}
