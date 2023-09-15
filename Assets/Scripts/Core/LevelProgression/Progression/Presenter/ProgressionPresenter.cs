using System;
using Core.LevelProgression.Progression.View;
using LevelProgression.Progression.Model;
using LevelProgression.Progression.Settings;

namespace Core.LevelProgression.Progression.Presenter
{
    public class ProgressionPresenter
    {
        private ProgressionModel _model;
        private ProgressionView _view;

        public event Action LevelPassed;

        public ProgressionPresenter(ProgressionView view, ProgressionSettings settings)
        {
            _model = new(settings);
            _view = view;
        }

        public int IncreaseLevelAndReturn()
        {
            _model.IncreaseLevel();
            _view.Fill(0);
            return _model.CurrentLevel;
        }

        public void IncreaseProgress(int amount = 1)
        {
            if (_model.LevelIsPassed) return;
            
            _model.IncreaseProgress(amount);
            float progressPercent = (_model.CurrentProgress * 100f / _model.ProgressCap) / 100f;
            _view.Fill(progressPercent);

            if (_model.LevelIsPassed)
            {
                LevelPassed?.Invoke();
            }
        }
    }
}