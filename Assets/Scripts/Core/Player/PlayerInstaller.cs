using LevelProgression.Upgrades.Events;
using Player.Movement.Model;
using Player.Movement.Presenter;
using Player.Movement.View;
using UnityEngine;

namespace Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private MovementView _movementView;
        [SerializeField] private MovementSettings _movementSettings;

        private Input.Input _input;
        private UpgradesEventManager _upgradesEventManager;

        private MovementPresenter _movement;

        public void Construct()
        {
            //TODO: REFACTOR TO MAKE STANDALONE MODULES FOR BOTH SCENES
            // _upgradesEventManager = DependencyContext.Dependencies.Get<UpgradesEventManager>();
            
            _input = new();
            _movement = new(_movementView, _movementSettings);

            // if (_upgradesEventManager != null)
            // {
            //     _upgradesEventManager.Subscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);
            // }

            _input.OnMove += _movement.Move;
        }

        public void Disable()
        {
            // _upgradesEventManager.Unsubscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);
            _input.OnMove -= _movement.Move;
            _input.Disable();
        }
    }
}