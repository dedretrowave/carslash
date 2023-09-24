using System;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Weapon.Arms
{
    public class MineExplosion : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out EnemyView enemy)) return;
            
            enemy.TakeDamage(_damage);
        }
    }
}