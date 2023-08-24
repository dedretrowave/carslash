using Enemies.View;
using UnityEngine;

namespace Weapon.Arms
{
    public class Rocket : Base.Arms
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private Vector3 _direction;

        public override void Launch(Vector3 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            Vector3 direction = Vector3.Normalize(_direction - transform.position);
            transform.position += direction * _speed * Time.deltaTime;
            transform.LookAt(_direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            
            if (!other.TryGetComponent(out EnemyView enemy)) return;
            
            Debug.Log("BAM");
            
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}