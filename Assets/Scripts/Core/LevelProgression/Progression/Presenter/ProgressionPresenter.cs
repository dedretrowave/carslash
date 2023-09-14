using System;
using LevelProgression.Progression.Model;
using LevelProgression.Progression.Settings;

namespace LevelProgression.Progression.Presenter
{
    public class ProgressionPresenter
    {
        private ProgressionModel _model;

        public event Action LevelPassed;

        public ProgressionPresenter(ProgressionSettings settings)
        {
            _model = new(settings);
        }

        public int IncreaseLevelAndReturn()
        {
            _model.IncreaseLevel();
            return _model.CurrentLevel;
        }

        public void IncreaseMoney(int amount = 1)
        {
            if (_model.LevelIsPassed) return;
            
            _model.IncreaseMoney(amount);

            if (_model.LevelIsPassed)
            {
                LevelPassed?.Invoke();
            }
        }
    }
}