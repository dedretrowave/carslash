using System;
using UnityEngine;

namespace Player.Movement.Model
{
    public class MovementModel
    {
        private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;

        public MovementModel(MovementSettings settings)
        {
            _moveSpeed = settings.MoveSpeed;
        }

        public void SetMoveSpeed(float speed)
        {
            if (speed <= 0) return;

            _moveSpeed = speed;
        }
    }

    [Serializable]
    public struct MovementSettings
    {
        [SerializeField] private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;
    }
}