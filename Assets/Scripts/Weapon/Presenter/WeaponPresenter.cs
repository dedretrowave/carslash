using System.Threading.Tasks;
using Enemies.View;
using UnityEngine;
using Weapon.Arms.Base;
using Weapon.Views;

namespace Weapon.Presenter
{
    public class WeaponPresenter
    {
        private WeaponView _view;

        private Transform _nearestEnemy;
        private float _nearestEnemyDistance;
        private Arms.Base.Arms _arms;

        public WeaponPresenter(WeaponView view)
        {
            _view = view;

            _view.OnEnemyInRange += SetNearestEnemy;

            FireContinuously();
        }

        public void Disable()
        {
            _arms = null;
            _nearestEnemy = null;

            _view.OnEnemyInRange -= SetNearestEnemy;
        }

        public void SetArms(Arms.Base.Arms arms)
        {
            _arms = arms;
        }

        private void SetNearestEnemy(EnemyView enemy)
        {
            if (_nearestEnemy == null
                || _nearestEnemyDistance 
                >= Vector3.Distance(enemy.transform.position, _view.Position))
            {
                SetEnemy(enemy.transform);
                FireContinuously();
            }
        }

        private async void FireContinuously()
        {
            while (_nearestEnemy != null 
                   && _arms != null)
            {
                _view.Launch(_nearestEnemy.position, _arms);
                await Task.Delay(2000);
            }
        }

        private void SetEnemy(Transform enemy)
        {
            _nearestEnemy = enemy;
            _nearestEnemyDistance = Vector3.Distance(_view.Position, _nearestEnemy.position);
        }
    }
}