using System;
using Enemies.View;
using UnityEngine;
using Weapon.Arms.Base;

namespace Weapon.Views
{
    public class WeaponView : MonoBehaviour
    {
        public Vector3 Position => transform.position;

        public Action<EnemyView> OnEnemyInRange;

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
    }
}