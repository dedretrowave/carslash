using Core.Player.Movement.View;
using DI;
using LevelProgression.Upgrades.Events;
using Player.Movement.Model;
using Player.Movement.Presenter;
using Player.Skin;
using Player.Skin.Presenter;
using Player.Skin.View;
using UnityEngine;
using Upgrades.Components;

namespace Core.Player
{
    public class PlayerLevelSceneInstaller : MonoBehaviour
    {
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private MovementView _movementView;
        [SerializeField] private SkinSettings _skinSettings;
        [SerializeField] private SkinView _skinView;

        private Input.Input _input;
        private UpgradesEventManager _upgradesEventManager;

        private MovementPresenter _movement;
        private SkinPresenter _skin;

        public void Construct()
        {
            _upgradesEventManager = DependencyContext.Dependencies.Get<UpgradesEventManager>();
            
            _input = new();
            // _skin = new(_skinView, _skinSettings);
            _movement = new(_movementView, _movementSettings);

            if (_upgradesEventManager != null)
            {
                _upgradesEventManager.Subscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);
            }

            _input.OnMove += _movement.Move;
        }

        public void Disable()
        {
            _upgradesEventManager.Unsubscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);
            _input.OnMove -= _movement.Move;
            _input.Disable();
        }
    }
}