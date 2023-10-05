using System.Collections;
using UnityEngine;

namespace Core.Combat.Weapon.Arms
{
    public class Miner : Base.Arms
    {
        [SerializeField] private Projectile.Base.Projectile _minesPrefab;
        
        private void Start()
        {
            StartShooting();
        }

        protected override IEnumerator Shoot()
        {
            Instantiate(_minesPrefab, transform.position, Quaternion.identity);
            OnShoot();
            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }
    }
}