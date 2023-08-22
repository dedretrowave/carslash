using Player.Health.Model;
using Player.Health.View;

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
            
            _view.Add(_model.Count);
        }

        public void Add(int count = 1)
        {
            _model.Add(count);
            _view.Add(_model.Count);
        }

        public void Reduce(int count = 1)
        {
            _model.Reduce(count);
            _view.Reduce(count);
        }
    }
}