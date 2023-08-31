using Enemies.View;
using UnityEngine;

namespace Weapon.Arms
{
    public class Rocket : Base.Arms
    {
        [SerializeField] private Transform _explosionPrefab;
        
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private Vector3 _direction;
        private bool _enemyIsSelected;

        public override void Launch(Vector3 direction)
        {
            _direction = Vector3.Normalize(direction - transform.position);
        }

        private void FixedUpdate()
        {
            transform.position += _direction * _speed * Time.deltaTime;
            transform.LookAt(transform.position + _direction);
        }

        public void TakeAim(Collider other)
        {
            if (_enemyIsSelected || !other.transform.TryGetComponent(out EnemyView enemy)) return;

            _enemyIsSelected = true;
            
            _direction = Vector3.Normalize(enemy.transform.position - transform.position);
        }

        public void Damage(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            enemy.TakeDamage(_damage);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}