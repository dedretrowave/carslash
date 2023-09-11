using Combat.Enemies.View;
using UnityEngine;

namespace Combat.Weapon.Arms.Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform _impactPrefab;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _travelEdgeX = 200; 
        [SerializeField] private float _travelEdgeZ = 200; 

        private Vector3 _direction;

        public void IncreaseDamage(float amount)
        {
            _damage *= amount;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            Debug.Log(_damage);
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