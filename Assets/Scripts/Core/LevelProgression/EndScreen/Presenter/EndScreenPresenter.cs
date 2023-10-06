using Core.LevelProgression.EndScreen.View;

namespace Core.LevelProgression.EndScreen.Presenter
{
    public class EndScreenPresenter
    {
        private EndScreenView _view;

        public EndScreenPresenter(EndScreenView view)
        {
            _view = view;
            _view.Hide();
        }

        public void Show(int maxLevel)
        {
            _view.SetMaxLevel(maxLevel);
            _view.Show();
        }
    }
}