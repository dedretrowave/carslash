using System;
using LevelProgression.Upgrades.Components;
using LevelProgression.Upgrades.Components.Base;
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

        public void OnUpgrade(Upgrade upgrade)
        {
            if (upgrade is not PropertyUpgrade) return;

            PropertyUpgrade propertyUpgrade = (PropertyUpgrade)upgrade;

            switch (propertyUpgrade.Type)
            {
                case UpgradeType.MoveSpeed:
                    _movement.IncreaseMoveSpeed(propertyUpgrade.IncreaseAmount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}