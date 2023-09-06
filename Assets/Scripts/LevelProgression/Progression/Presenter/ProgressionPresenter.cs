using System;
using LevelProgression.Progression.Model;

namespace LevelProgression.Progression.Presenter
{
    public class ProgressionPresenter
    {
        private ProgressionModel _model;

        public event Action LevelPassed;

        public ProgressionPresenter()
        {
            _model = new();
        }

        public int IncreaseLevelAndReturn()
        {
            _model.IncreaseLevel();
            return _model.CurrentLevel;
        }

        public void IncreaseMoney(int amount = 1)
        {
            _model.IncreaseMoney(amount);
        }
    }
}