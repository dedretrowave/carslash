using Player.Skin.Model;
using Player.Skin.View;

namespace Player.Skin.Presenter
{
    public class SkinPresenter
    {
        private SkinModel _model;
        
        private SkinView _view;

        public SkinPresenter(SkinView view, SkinSettings settings)
        {
            _model = new(settings);

            _view = view;
            
            _view.Show(_model.Skin);
        }

        public void Set(Core.Player.Skin.Components.Skin skin)
        {
            _model.Set(skin);
            _view.Show(_model.Skin);
        }
    }
}