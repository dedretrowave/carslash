using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile
{
    public class MovingProjectile : Core.Combat.Weapon.Arms.Projectile.Base.Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _travelEdgeX = 200;
        [SerializeField] private float _travelEdgeZ = 200;
        
        private Vector3 _direction;
        
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        
        private void FixedUpdate()
        {
            if (transform.position.x >= _travelEdgeX 
                || transform.position.x <= -_travelEdgeX
                || transform.position.z >= _travelEdgeZ 
                || transform.position.z <= -_travelEdgeZ)
            {
                Destroy(gameObject);
            }
            
            transform.position += _direction * _speed * Time.deltaTime;
            transform.LookAt(transform.position + _direction);
        }
    }
}