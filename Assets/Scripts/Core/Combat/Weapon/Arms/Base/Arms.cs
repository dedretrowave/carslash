using System.Collections;
using UnityEngine;

namespace Combat.Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        [Header("Description")]
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] protected Projectile.Projectile projectile;
        [SerializeField] protected int delayBetweenShotsInSecs = 2;

        public string Name => _name;
        public string Description => _description;

        protected float baseDamageIncrease = 1;
        
        protected Coroutine shootingRoutine;
        
        private void OnDisable()
        {
            if (shootingRoutine == null) return;
            
            StopCoroutine(shootingRoutine);
            shootingRoutine = null;
        }

        public void SetDamageIncrease(float amount)
        {
            baseDamageIncrease = amount;
        }

        protected void StartShooting()
        {
            shootingRoutine = StartCoroutine(Shoot());
        }

        protected abstract IEnumerator Shoot();
    }
}