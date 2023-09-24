using System.Collections;
using UnityEngine;

namespace Core.Combat.Weapon.Arms
{
    public class Laser : Base.Arms
    {
        [SerializeField] private Projectile.Base.Projectile _beam;
        
        private void Start()
        {
            StartShooting();
        }
        
        protected override IEnumerator Shoot()
        {
            Instantiate(_beam, MuzzlePosition, transform.rotation);
            OnShoot();
            yield return new WaitForSeconds(delayBetweenShotsInSecs);
            yield return Shoot();
        }
    }
}