using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class Input
    {
        private Controls _controls;
        private bool _isHeld;

        public event Action<Vector3> OnMove;

        public Input()
        {
            _controls = new();

            _controls.Enable();

            _controls.Movement.Move.started += OnMovement;
            _controls.Movement.Move.performed += OnMovement;
            _controls.Movement.Move.canceled += OnMovement;
        }

        public void Disable()
        {
            _controls.Movement.Move.started -= OnMovement;
            _controls.Movement.Move.performed -= OnMovement;
            _controls.Movement.Move.canceled -= OnMovement;
            
            _controls.Disable();
        }

        private void OnMovement(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector3>());
        }
    }
}