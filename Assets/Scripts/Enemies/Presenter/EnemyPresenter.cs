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

        public event Action<Transform, EnemyPresenter> OnCollide;

        public EnemyPresenter(EnemyView view, Transform player)
        {
            _model = new();
            
            _view = view;
            
            _view.Follow(player);

            _view.OnCollide += OnCollision;
            _view.OnDamage += TakeDamage;
            _model.OnOutOfHealth += Destroy;
        }

        private void Disable()
        {
            _view.OnCollide -= OnCollision;
            _view.OnDamage -= TakeDamage;
            _model.OnOutOfHealth -= Destroy;
        }

        private void OnCollision(Transform collider)
        {
            OnCollide?.Invoke(collider, this);
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