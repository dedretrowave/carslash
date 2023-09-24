using System;
using System.Collections;
using UnityEngine;

namespace Core.Combat.Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        [Header("Description")]
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] protected int delayBetweenShotsInSecs = 2;

        [Header("Components")]
        [SerializeField] private Transform _muzzlePosition;

        protected Vector3 MuzzlePosition => _muzzlePosition.position;

        public string Name => _name;
        public string Description => _description;

        protected float baseDamageIncrease = 1;
        
        protected Coroutine shootingRoutine;

        public event Action Shot;
        
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

        public void StopShooting()
        {
            if (shootingRoutine == null) return;
            
            StopCoroutine(shootingRoutine);
            shootingRoutine = null;
        }

        public void StartShooting()
        {
            shootingRoutine = StartCoroutine(Shoot());
        }

        protected void OnShoot()
        {
            Shot?.Invoke();
        }

        protected abstract IEnumerator Shoot();
    }
}