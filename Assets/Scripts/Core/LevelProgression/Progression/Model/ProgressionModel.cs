using System;
using LevelProgression.Progression.Settings;
using UnityEngine;

namespace Core.LevelProgression.Progression.Model
{
    public class ProgressionModel
    {
        private string _key;
        
        private CurrentLevelInt _currentLevel = new();
        private int _progressCap;
        private int _progressCapBase;
        private int _currentProgress;
        private bool _levelIsPassed;
        private int _maxLevelReached;

        public CurrentLevelInt CurrentLevel => _currentLevel;
        public bool LevelIsPassed => _levelIsPassed;
        public ProgressionInt CurrentProgressPercent { get; } = new();
        public int MaxLevelReached => _maxLevelReached;

        public ProgressionModel(ProgressionSettings settings)
        {
            _key = typeof(ProgressionModel).ToString();
            _currentLevel.Value = 1;
            _progressCap = _progressCapBase = settings.MoneyToIncreaseLevelBase;
            _maxLevelReached = PlayerPrefs.GetInt(_key, 0);
        }

        public ProgressInt GetProgressInt<T>(T type) where T : class
        {
            if (ReferenceEquals(type, typeof(CurrentLevelInt)))
            {
                return _currentLevel;
            }

            if (ReferenceEquals(type, typeof(ProgressionInt)))
            {
                return CurrentProgressPercent;
            }

            return null;
        }

        public void IncreaseLevel()
        {
            _currentLevel.Value++;
            _progressCap = _progressCapBase * _currentLevel.Value;
            _currentProgress = 0;
            _levelIsPassed = false;

            if (_currentLevel.Value > _maxLevelReached)
            {
                _maxLevelReached = _currentLevel.Value;
                PlayerPrefs.SetInt(_key, _maxLevelReached);
            }
        }

        public void IncreaseProgress(int amount = 1)
        {
            _currentProgress += amount;

            if (_currentProgress >= _progressCap)
            {
                _levelIsPassed = true;
            }

            CurrentProgressPercent.Value = (_currentProgress * 100 / _progressCap);
        }
    }
}