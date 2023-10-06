using System;
using System.Collections;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Weapon.Arms.Projectile.Base
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _destroyAfterInSecs = 60f;
        [SerializeField] protected Transform impactPrefab;

        [SerializeField] protected float damage;

        private Coroutine _destroyRoutine;

        private void Awake()
        {
            _destroyRoutine = StartCoroutine(DestroyAfter());
        }

        private void OnDestroy()
        {
            if (_destroyRoutine != null)
            {
                StopCoroutine(_destroyRoutine);
            }
        }

        private IEnumerator DestroyAfter()
        {
            yield return new WaitForSeconds(_destroyAfterInSecs);
            
            Destroy(gameObject);
        }

        public void IncreaseDamage(float amount)
        {
            damage *= amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            Damage(enemy);
        }

        protected virtual void Damage(EnemyView enemy)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}