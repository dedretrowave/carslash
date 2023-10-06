using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile
{
    public class MovingProjectile : Core.Combat.Weapon.Arms.Projectile.Base.Projectile
    {
        [SerializeField] private float _speed;
        
        private Vector3 _direction;
        
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        
        private void FixedUpdate()
        {
            transform.position += _direction * _speed * Time.deltaTime;
            transform.LookAt(transform.position + _direction);
        }
    }
}