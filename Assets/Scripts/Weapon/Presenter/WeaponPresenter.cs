using System.Threading.Tasks;
using Enemies.View;
using UnityEngine;
using Weapon.Views;

namespace Weapon.Presenter
{
    public class WeaponPresenter
    {
        private WeaponView _view;
        
        private Arms.Base.Arms _arms;

        private int _enemiesInRange;
        private bool _isFiring;

        public WeaponPresenter(WeaponView view)
        {
            _view = view;

            _view.OnEnemyInRange += OnEnemyInRange;
            _view.OnEnemyOutOfRange += OnEnemyOutOfRange;
        }

        public void Disable()
        {
            _arms = null;
            _isFiring = false;

            _view.OnEnemyInRange -= OnEnemyInRange;
            _view.OnEnemyOutOfRange -= OnEnemyOutOfRange;
        }

        public void SetArms(Arms.Base.Arms arms)
        {
            _arms = arms;
        }

        private void OnEnemyInRange(EnemyView enemyView)
        {
            _enemiesInRange++;
            enemyView.OnDestroy += OnEnemyOutOfRange;

            if (_enemiesInRange > 0 && !_isFiring)
            {
                Fire();
            }
        }

        private void OnEnemyOutOfRange(EnemyView enemyView)
        {
            _enemiesInRange--;
            enemyView.OnDestroy -= OnEnemyOutOfRange;

            if (_enemiesInRange == 0)
            {
                _isFiring = false;
            }
        }

        private async void Fire()
        {
            while (_enemiesInRange > 0 || _isFiring)
            {
                if (_view == null) return;
                
                _isFiring = true;
                _view.Launch(Vector3.back, _arms);
                await Task.Delay(_arms.DelayBetweenShots);
            }
        }
    }
}