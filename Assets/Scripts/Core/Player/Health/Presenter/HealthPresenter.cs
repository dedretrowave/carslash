using System;
using Core.Player.Health.View;
using Player.Health.Model;

namespace Player.Health.Presenter
{
    public class HealthPresenter
    {
        private HealthModel _model;

        private HealthView _view;

        public event Action OutOfHealth;

        public HealthPresenter(HealthView view)
        {
            _model = new(5);

            _view = view;
            
            _view.DrawAndFill(_model.Count, _model.MaxCount);
            _model.OutOfHealth += OnOutOfHealth;
        }

        public void Disable()
        {
            _model.OutOfHealth -= OnOutOfHealth;
        }

        private void OnOutOfHealth()
        {
            OutOfHealth?.Invoke();
        }

        public void Regen(float count = 1)
        {
            Regen((int) count);
        }

        public void Regen(int count = 1)
        {
            _model.Regen(count);
            _view.DrawAndFill(_model.Count, _model.MaxCount);
        }
        
        public void Add(float count = 1)
        {
            Add((int) count);
        }

        public void Add(int count = 1)
        {
            _model.IncreaseMax(count);
            _view.DrawAndFill(_model.Count, _model.MaxCount);
        }

        public void Reduce(int count = 1)
        {
            _model.Reduce(count);
            _view.DrawAndFill(_model.Count, _model.MaxCount);
        }
    }
}