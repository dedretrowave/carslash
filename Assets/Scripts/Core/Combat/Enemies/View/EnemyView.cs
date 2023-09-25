using System;
using Economics.Money;
using UnityEngine;

namespace Core.Combat.Enemies.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private MoneySpawner _moneySpawner;
        [SerializeField] private EnemyAnimations _enemyAnimations;
        [SerializeField] private Collider _collider;
        [SerializeField] private float _speed = 5f;
        
        private Transform _followTarget;

        public event Action<float> DamageTaken;
        public event Action<Transform> Collide;

        public void Follow(Transform target)
        {
            _followTarget = target;
        }

        public void OnTriggerEnter(Collider other)
        {
            Collide?.Invoke(other.transform);
        }

        public void TakeDamage(float damage)
        {
            DamageTaken?.Invoke(damage);
        }

        public void TakeDamage()
        {
            _enemyAnimations.PlayHurt();
        }

        public void CleanDestroy()
        {
            Destroy(gameObject);
        }

        public void Destroy()
        {
            _followTarget = null;
            _enemyAnimations.PlayDead();
            _moneySpawner.Spawn();
            _collider.enabled = false;
        }

        private void FixedUpdate()
        {
            if (_followTarget == null) return;
            
            Vector3 direction = Vector3.Normalize(_followTarget.position - transform.position);
            transform.position += direction * _speed * Time.deltaTime;
            transform.LookAt(_followTarget.position);
        }
    }
}