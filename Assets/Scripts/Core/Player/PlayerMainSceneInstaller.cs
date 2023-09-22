using Core.Player.Movement.View;
using LevelProgression.Upgrades.Events;
using Player.Movement.Model;
using Player.Movement.Presenter;
using UnityEngine;

namespace Core.Player
{
    public class PlayerMainSceneInstaller : MonoBehaviour
    {
        [SerializeField] private MovementView _movementView;
        [SerializeField] private MovementSettings _movementSettings;

        private Input.Input _input;
        private UpgradesEventManager _upgradesEventManager;

        private MovementPresenter _movement;

        public void Construct()
        {
            _input = new();
            _movement = new(_movementView, _movementSettings);

            _input.OnMove += _movement.Move;
        }

        public void Disable()
        {
            _input.OnMove -= _movement.Move;
            _input.Disable();
        }
    }
}