using System.Collections;
using Core.Combat.Enemies.View;
using Core.Combat.Weapon.Arms.Projectile;
using UnityEngine;

namespace Core.Combat.Weapon.Arms
{
    public class RocketLauncher : Base.Arms
    {
        [SerializeField] private MovingProjectile _projectilePrefab;
        [SerializeField] private Collider _enemyDetectionCollider;
        
        private EnemyView _selectedEnemy;

        protected override IEnumerator Shoot()
        {
            _enemyDetectionCollider.enabled = true;
            
            if (_selectedEnemy == null)
            {
                _enemyDetectionCollider.enabled = true;

                if (shootingRoutine == null) yield break;

                StopCoroutine(shootingRoutine);
                shootingRoutine = null;
                yield break;
            }

            _enemyDetectionCollider.enabled = false;
            
            Vector3 shootingDirection = Vector3.Normalize(_selectedEnemy.transform.position - transform.position);
            
            MovingProjectile spawnedProjectile = 
                 Instantiate(_projectilePrefab, MuzzlePosition, Quaternion.identity);
            
            spawnedProjectile.SetDirection(shootingDirection);
            spawnedProjectile.IncreaseDamage(baseDamageIncrease);
            OnShoot();
            
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