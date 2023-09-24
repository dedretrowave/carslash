using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile.Base
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected Transform impactPrefab;
        
        [SerializeField] protected float damage;

        public void IncreaseDamage(float amount)
        {
            damage *= amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            Damage(enemy);
        }

        protected virtual void Damage(EnemyView enemy)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}