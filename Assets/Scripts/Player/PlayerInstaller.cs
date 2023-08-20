using Player.Movement.Model;
using Player.Movement.Presenter;
using Player.Movement.View;
using UnityEngine;

namespace Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private MovementView _movementView;

        private Input.Input _input;

        private MovementPresenter _movement;

        private void Start()
        {
            _input = new();
            _movement = new(_movementView, _movementSettings);

            _input.OnMove += _movement.Move;
        }

        private void OnDisable()
        {
            _input.OnMove -= _movement.Move;
            _input.Disable();
        }
    }
}