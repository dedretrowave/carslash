using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Combat.Weapon.Arms
{
    public class Gatling : global::Combat.Weapon.Arms.Base.Arms
    {
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
                
                global::Combat.Weapon.Arms.Projectile.Projectile spawnedProjectile = 
                    Instantiate(projectile, transform.position, transform.rotation);
                spawnedProjectile.SetDirection(shootingDirection);
                yield return new WaitForSeconds(1 / _shootingRate);
            }

            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }
    }
}