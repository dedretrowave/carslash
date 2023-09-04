using System.Collections;
using Enemies.View;
using UnityEngine;

namespace Weapon.Arms
{
    public class RocketLauncher : Base.Arms
    {
        [SerializeField] private Projectile.Projectile _projectile;
        [SerializeField] private Collider _enemyDetectionCollider;

        private EnemyView _selectedEnemy;
        private Coroutine _shootingRoutine;

        private void StartShooting()
        {
            _shootingRoutine = StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            _enemyDetectionCollider.enabled = true;
            
            if (_selectedEnemy == null)
            {
                _enemyDetectionCollider.enabled = true;
                StopCoroutine(_shootingRoutine);
                _shootingRoutine = null;
                yield break;
            }

            _enemyDetectionCollider.enabled = false;
            
            Vector3 shootingDirection = Vector3.Normalize(_selectedEnemy.transform.position - transform.position);
            
            Projectile.Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
            projectile.SetDirection(shootingDirection);
            _selectedEnemy = null;

            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EnemyView enemy)) return;

            _selectedEnemy = enemy;

            if (_shootingRoutine == null)
            {
                StartShooting();
            }
        }
    }
}