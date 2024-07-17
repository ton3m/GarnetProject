using UnityEngine;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService
{
    public class TestInput : MonoBehaviour
    {
        private IInputHandler _inputHandler;

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Start()
        {
            _inputHandler.Actions.Gameplay.InventoryPerform.performed += ctx => Debug.Log("Performed");
        }

        private void OnDisable()
        {
            _inputHandler.Actions.Gameplay.InventoryPerform.performed -= ctx => Debug.Log("Performed");
        }
    }
}
