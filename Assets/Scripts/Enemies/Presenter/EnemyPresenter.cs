using System;
using Enemies.Model;
using Enemies.View;
using UnityEngine;
using Object = UnityEngine.Object;

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
        }

        private void Disable()
        {
            _view.OnCollide -= OnCollision;
        }

        private void OnCollision(Transform collider)
        {
            OnCollide?.Invoke(collider, this);
        }

        public void Destroy()
        {
            Disable();
            Object.Destroy(_view.gameObject);
        }
    }
}