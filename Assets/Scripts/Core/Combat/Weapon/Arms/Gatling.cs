using System.Collections;
using Core.Combat.Weapon.Arms.Projectile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Combat.Weapon.Arms
{
    public class Gatling : Base.Arms
    {
        [SerializeField] private MovingProjectile _projectilePrefab;
        [SerializeField] private int _minProjectilesAmount;
        [SerializeField] private int _maxProjectilesAmount;
        [SerializeField] private float _shootingSpread = 5;
        [SerializeField] private float _shootingRate = 10;

        private void Start()
        {
            StartShooting();
        }

        protected override IEnumerator Shoot()
        {
            int projectilesAmount = Random.Range(_minProjectilesAmount, _maxProjectilesAmount);

            for (int i = 0; i < projectilesAmount; i++)
            {
                Vector3 shootingDirection = transform.forward 
                                            + transform.right 
                                            * Random.Range(-_shootingSpread, _shootingSpread);
                
                MovingProjectile spawnedProjectile = 
                    Instantiate(_projectilePrefab, MuzzlePosition, transform.rotation);
                
                spawnedProjectile.SetDirection(shootingDirection);
                spawnedProjectile.IncreaseDamage(baseDamageIncrease);
                
                OnShoot();
                yield return new WaitForSeconds(1 / _shootingRate);
            }
            
            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }
    }
}