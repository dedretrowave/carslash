using System;
using Combat.Enemies.Model;
using Combat.Enemies.View;
using UnityEngine;

namespace Combat.Enemies.Presenter
{
    public class EnemyPresenter
    {
        private EnemyModel _model;
        
        private EnemyView _view;

        public event Action<Transform, EnemyPresenter> Collide;
        public event Action<EnemyPresenter> Destroyed; 
            
        public EnemyPresenter(EnemyView view, Transform player)
        {
            _model = new();
            
            _view = view;
            
            _view.Follow(player);

            _view.Collide += OnCollision;
            _view.Damage += TakeDamage;
            _model.OutOfHealth += Destroy;
        }

        private void Disable()
        {
            _view.Collide -= OnCollision;
            _view.Damage -= TakeDamage;
            _model.OutOfHealth -= Destroy;
        }

        private void OnCollision(Transform collider)
        {
            Collide?.Invoke(collider, this);
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);
            Disable();
            _view.Destroy();
        }

        public void TakeDamage(float amount)
        {
            _model.ReduceHealth(amount);
        }
    }
}