using GarnnetProject.Assets.CodeBase.Runtime.App.Core.PlayerConfigration;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Player
{
    public class ClickBehaviour : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private DamagePopUpController _popUpController;
        private PlayerConfigState _data;
        private RaycastHit _raycastHit;

        [Inject]
        private void Construct(IInputHandler inputHandler, DamagePopUpController popUpController, PlayerConfigState configState)
        {
            _inputHandler = inputHandler;
            _popUpController = popUpController;
            _data = configState;
        }

        private void Start()
        {
            _inputHandler.Actions.Gameplay.Click.performed += ClickPerformed;
        }

        private void OnDestroy()
        {
            _inputHandler.Actions.Gameplay.Click.performed -= ClickPerformed;
        }

        private void ClickPerformed(InputAction.CallbackContext context)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out _raycastHit, 100))
            {
                if (_raycastHit.transform.TryGetComponent(out IDamageable damageable))
                {
                    if (damageable.ApplyDamage(_data.ClickDamage))
                    {
                        _popUpController.Show(_raycastHit.point, _data.ClickDamage);
                    }
                }
            }
        }
    }
}
