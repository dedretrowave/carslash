using System.Collections;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile
{
    public class PiercingProjectile : Base.Projectile
    {
        [SerializeField] private float _destroyTimeInSecs = .2f;

        private void Awake()
        {
            StartCoroutine(DestroyAfterTimeout());
        }
        
        protected override void Damage(EnemyView enemy)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactPrefab, enemy.transform.position, Quaternion.identity);
        }

        private IEnumerator DestroyAfterTimeout()
        {
            yield return new WaitForSeconds(_destroyTimeInSecs);
            
            Destroy(gameObject);
        }
    }
}