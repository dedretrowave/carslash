using System.Collections;
using UnityEngine;

namespace Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        [SerializeField] protected Projectile.Projectile projectile;
        [SerializeField] protected int delayBetweenShotsInSecs = 2;
        
        protected Coroutine shootingRoutine;
        
        private void OnDisable()
        {
            if (shootingRoutine == null) return;
            
            StopCoroutine(shootingRoutine);
            shootingRoutine = null;
        }

        protected void StartShooting()
        {
            shootingRoutine = StartCoroutine(Shoot());
        }

        protected abstract IEnumerator Shoot();
    }
}