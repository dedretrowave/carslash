using System;

namespace LevelProgression.Progression.Model
{
    public class ProgressionModel
    {
        private int _currentLevel;
        private int _moneyToIncreaseLevel;
        private int _currentMoney;

        public int CurrentLevel => _currentLevel;

        public event Action LevelPassed;

        public ProgressionModel()
        {
            _currentLevel = 1;
            _moneyToIncreaseLevel = 100;
        }

        public void IncreaseLevel()
        {
            _currentLevel++;
        }

        public void IncreaseMoney(int amount = 1)
        {
            _currentMoney += amount;

            if (_currentMoney >= _moneyToIncreaseLevel)
            {
                LevelPassed?.Invoke();
            }
        }
    }
}