using System;
using Enemies.Model;
using Enemies.View;
using UnityEngine;

namespace Enemies.Presenter
{
    public class EnemyPresenter
    {
        private EnemyModel _model;
        
        private EnemyView _view;

        public event Action<Transform, EnemyPresenter> Collide;

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
            Disable();
            _view.Destroy();
        }

        public void TakeDamage(float amount)
        {
            _model.ReduceHealth(amount);
        }
    }
}