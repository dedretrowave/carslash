using DG.Tweening;
using UnityEngine;

namespace Player.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        [SerializeField] private float _tweenMoveSpeed;
        [SerializeField] private float _tweenTurnSpeed;
        
        private Vector3 _direction;
        private float _speed;

        public void Move(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private void FixedUpdate()
        {
            Vector3 movement = transform.position + _direction * (_speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movement) <= 1f) return;
            
            transform.DOMove(movement, _tweenMoveSpeed);
            transform.DOLookAt(movement, _tweenTurnSpeed);
        }
    }
}