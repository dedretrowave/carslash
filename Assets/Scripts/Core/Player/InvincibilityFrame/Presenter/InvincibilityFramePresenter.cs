using Core.Player.InvincibilityFrame.Model;
using Core.Player.InvincibilityFrame.View;

namespace Core.Player.InvincibilityFrame.Presenter
{
    public class InvincibilityFramePresenter
    {
        private InvincibilityFrameModel _model;
        private InvincibilityFrameView _view;

        public bool IsActive => _model.IsActive;

        public InvincibilityFramePresenter(InvincibilityFrameSettings settings, InvincibilityFrameView view)
        {
            _model = new(settings);
            
            _view = view;

            _view.End += OnEnd;
        }

        ~InvincibilityFramePresenter()
        {
            _view.End -= OnEnd;
        }

        private void OnEnd()
        {
            _model.Deactivate();
        }
        
        public void Activate()
        {
            _model.Activate();
            _view.Play(_model.DurationInSecs);
        }
    }
}