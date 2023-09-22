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
        
        protected EnemyView View;

        public event Action<Transform, EnemyPresenter> Collide;
        public event Action<EnemyPresenter> Destroyed;
        
        public EnemyPresenter(EnemyView view, Transform player, EnemySettings settings)
        {
            _model = new(settings);
            
            View = view;
            
            View.Follow(player);

            View.Collide += OnCollision;
            View.DamageTaken += TakeDamage;
            _model.OutOfHealth += Destroy;
        }

        private void Disable()
        {
            View.Collide -= OnCollision;
            View.DamageTaken -= TakeDamage;
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
            View.CleanDestroy();
        }

        private void Destroy()
        {
            Destroyed?.Invoke(this);
            Disable();
            View.Destroy();
        }

        public virtual void OnAttack(Transform player)
        {
            Destroy();
        }

        public void TakeDamage(float amount)
        {
            _model.ReduceHealth(amount);
        }
    }
}