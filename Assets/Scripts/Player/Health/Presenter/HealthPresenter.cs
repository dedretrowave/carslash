using Player.Health.Model;
using Player.Health.View;
using UnityEngine;

namespace Player.Health.Presenter
{
    public class HealthPresenter
    {
        private HealthModel _model;

        private HealthView _view;

        public HealthPresenter(HealthView view)
        {
            _model = new(5);

            _view = view;
            
            _view.DrawAndFill(_model.Count, _model.MaxCount);
        }

        public void Regen(int count = 1)
        {
            _model.Regen(count);
            _view.DrawAndFill(_model.Count, _model.MaxCount);
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