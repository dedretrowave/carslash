using System;
using DG.Tweening;
using UnityEngine;

namespace Enemies.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Transform _explosionPrefab;

        private float _tweenSpeed = 10f;
        private const float TurnSpeed = .3f;
        private Transform _followTarget;

        public event Action<Transform> OnCollide;

        public void Init(int moveSpeed)
        {
            _tweenSpeed = moveSpeed;
        }

        public void Follow(Transform target)
        {
            _followTarget = target;
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCollide?.Invoke(other.transform);
        }

        private void FixedUpdate()
        {
            Vector3 direction = Vector3.Normalize(_followTarget.position - transform.position);
            transform.position += direction * _tweenSpeed * Time.deltaTime;
            transform.LookAt(_followTarget.position);
        }
    }
}