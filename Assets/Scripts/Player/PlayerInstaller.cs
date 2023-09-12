using System;
using DI;
using LevelProgression.Upgrades.Components;
using LevelProgression.Upgrades.Events;
using LevelProgression.Upgrades.Upgrades;
using LevelProgression.Upgrades.Upgrades.Base;
using Player.Movement.Model;
using Player.Movement.Presenter;
using Player.Movement.View;
using UnityEngine;
using Upgrades.Components;

namespace Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private MovementView _movementView;

        private Input.Input _input;
        private UpgradesEventManager _upgradesEventManager;

        private MovementPresenter _movement;

        public void Construct()
        {
            _upgradesEventManager = DependencyContext.Dependencies.Get<UpgradesEventManager>();
            
            _input = new();
            _movement = new(_movementView, _movementSettings);
            
            _upgradesEventManager.Subscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);

            _input.OnMove += _movement.Move;
        }

        public void Disable()
        {
            _upgradesEventManager.Unsubscribe<float>(UpgradeType.MoveSpeed, _movement.IncreaseMoveSpeed);
            _input.OnMove -= _movement.Move;
            _input.Disable();
        }

        public void OnUpgrade(Upgrade upgrade)
        {
            if (upgrade is not PropertyUpgrade propertyUpgrade) return;

            switch (propertyUpgrade.Type)
            {
                case UpgradeType.MoveSpeed:
                    _movement.IncreaseMoveSpeed(propertyUpgrade.IncreaseAmount);
                    break;
                default:
                    return;
            }
        }
    }
}