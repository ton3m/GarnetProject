using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.InputService;
using UnityEngine;
using VContainer;

namespace GarnnetProject
{
    public class ClickBehaviour : MonoBehaviour
    {
        [SerializeField, Min(0)] private int _damage; // to stat system 
        private IInputHandler _inputHandler;
        RaycastHit _raycastHit;

        [Inject]
        private void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Start()
        {
            _inputHandler.Actions.Gameplay.Click.performed += ctx => ClickPerformed();
        }

        private void OnDisable()
        {
            _inputHandler.Actions.Gameplay.Click.performed -= ctx => ClickPerformed();
        }

        private void ClickPerformed()
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(mouseRay, out _raycastHit, 100))
            {
                if (_raycastHit.transform.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_damage);
                }
            }
        }
    }
}
