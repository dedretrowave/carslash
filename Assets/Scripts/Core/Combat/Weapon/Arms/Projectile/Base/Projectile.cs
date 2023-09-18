using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile.Base
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform _impactPrefab;
        
        [SerializeField] private float _damage;

        public void IncreaseDamage(float amount)
        {
            _damage *= amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            enemy.TakeDamage(_damage);
            Instantiate(_impactPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}