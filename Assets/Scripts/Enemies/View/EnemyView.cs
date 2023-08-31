using System;
using Economics.Money;
using UnityEngine;

namespace Enemies.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Transform _explosionPrefab;
        [SerializeField] private MoneySpawner _moneySpawner;

        private float _tweenSpeed = 10f;
        private Transform _followTarget;

        public event Action<float> OnDamage;

        public event Action<Transform> OnCollide;
        public event Action<EnemyView> OnDestroy;

        public void Follow(Transform target)
        {
            _followTarget = target;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCollide?.Invoke(other.transform);
        }

        public void TakeDamage(float damage)
        {
            OnDamage?.Invoke(damage);
        }

        public void Destroy()
        {
            _moneySpawner.Spawn();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            OnDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Vector3 direction = Vector3.Normalize(_followTarget.position - transform.position);
            transform.position += direction * _tweenSpeed * Time.deltaTime;
            transform.LookAt(_followTarget.position);
        }
    }
}