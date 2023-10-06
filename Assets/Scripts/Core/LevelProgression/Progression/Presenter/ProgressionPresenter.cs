using System;
using System.Collections.Generic;
using Core.LevelProgression.Progression.Model;
using Core.LevelProgression.Progression.View;
using LevelProgression.Progression.Settings;

namespace Core.LevelProgression.Progression.Presenter
{
    public class ProgressionPresenter
    {
        private ProgressionModel _model;
        private List<ProgressView> _views;

        public event Action LevelPassed;

        public ProgressionPresenter(List<ProgressView> views, ProgressionSettings settings)
        {
            _model = new(settings);
            _views = new(views);
            
            ShowViews();
        }

        public int GetMaxLevel()
        {
            return _model.MaxLevelReached;
        }

        public int IncreaseLevelAndReturn()
        {
            _model.IncreaseLevel();
            
            return _model.CurrentLevel.Value;
        }

        public void IncreaseProgress(int amount = 1)
        {
            if (_model.LevelIsPassed) return;
            
            _model.IncreaseProgress(amount);
            ShowViews();

            if (_model.LevelIsPassed)
            {
                LevelPassed?.Invoke();
            }
        }
        
        private void ShowViews()
        {
            if (_views.Count == 0) return;
            
            _views.ForEach(view =>
            {
                view.Show(_model.GetProgressInt(view.GetType()));
            });
        }
    }
}