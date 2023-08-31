using System;
using Enemies.View;
using UnityEngine;

namespace Weapon.Views
{
    public class WeaponView : MonoBehaviour
    {
        public event Action<EnemyView> OnEnemyInRange;
        public event Action<EnemyView> OnEnemyOutOfRange;

        public void Launch(Vector3 direction, Arms.Base.Arms arms)
        {
            Arms.Base.Arms newArms = Instantiate(arms, transform.position, Quaternion.identity);
            
             newArms.Launch(direction);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out EnemyView enemy)) return;
            OnEnemyInRange?.Invoke(enemy);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out EnemyView enemy)) return;
            OnEnemyOutOfRange?.Invoke(enemy);
        }
    }
}