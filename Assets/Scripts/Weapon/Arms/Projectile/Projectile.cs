using Enemies.View;
using UnityEngine;

namespace Weapon.Arms.Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform _impactPrefab;
        
        [SerializeField] private int _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _travelEdgeX = 200; 
        [SerializeField] private float _travelEdgeZ = 200; 

        private Vector3 _direction;

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            enemy.TakeDamage(_damage);
            Instantiate(_impactPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
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