using System;
using Core.Combat.Enemies.Components;
using Core.Combat.Enemies.Model;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Enemies.Presenter
{
    public class EnemyPresenter
    {
        private EnemyModel _model;
        
        private EnemyView _view;

        public event Action<Transform, EnemyPresenter> Collide;
        public event Action<EnemyPresenter> Destroyed;
        
        public EnemyPresenter(EnemyView view, Transform player, EnemySettings settings)
        {
            _model = new(settings);
            
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

        public void CleanDestroy()
        {
            Destroyed?.Invoke(this);
            Disable();
            _view.CleanDestroy();
        }

        private void Destroy()
        {
            Destroyed?.Invoke(this);
            Disable();
            _view.Destroy();
        }

        public void OnAttack(Transform player)
        {
            Destroy();
        }

        public void TakeDamage(float amount)
        {
            _model.ReduceHealth(amount);
        }
    }
}