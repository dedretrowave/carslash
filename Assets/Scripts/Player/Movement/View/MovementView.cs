using System;
using UnityEngine;

namespace Player.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        private Vector3 _direction;
        private float _speed;
        
        public Vector3 Position => transform.position;
        
        public void Move(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private void FixedUpdate()
        {
            transform.position += _direction * (_speed * Time.deltaTime);
        }
    }
}