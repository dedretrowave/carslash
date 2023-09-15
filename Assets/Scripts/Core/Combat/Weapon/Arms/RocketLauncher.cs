using System.Collections;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Combat.Weapon.Arms
{
    public class RocketLauncher : global::Combat.Weapon.Arms.Base.Arms
    {
        [SerializeField] private Collider _enemyDetectionCollider;
        
        private EnemyView _selectedEnemy;

        protected override IEnumerator Shoot()
        {
            _enemyDetectionCollider.enabled = true;
            
            if (_selectedEnemy == null)
            {
                _enemyDetectionCollider.enabled = true;
                StopCoroutine(shootingRoutine);
                shootingRoutine = null;
                yield break;
            }

            _enemyDetectionCollider.enabled = false;
            
            Vector3 shootingDirection = Vector3.Normalize(_selectedEnemy.transform.position - transform.position);
            
            global::Combat.Weapon.Arms.Projectile.Projectile spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            
            spawnedProjectile.SetDirection(shootingDirection);
            spawnedProjectile.IncreaseDamage(baseDamageIncrease);
            
            _selectedEnemy = null;

            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EnemyView enemy)) return;

            _selectedEnemy = enemy;

            if (shootingRoutine == null)
            {
                StartShooting();
            }
        }
    }
}