using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _turnSpeed = 200f;

        private Vector3 _direction;
        private float _speed;

        public void Move(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private float _timeValue;
        
        private void FixedUpdate()
        {
            Vector3 movement = _direction * _speed;

            if (movement != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed);
            }
            
            _rigidbody.velocity = movement;
        }
    }
}