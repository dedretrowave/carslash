using System;

namespace LevelProgression.Progression.Model
{
    public class ProgressionModel
    {
        private int _currentLevel;
        private int _moneyToIncreaseLevel;
        private int _currentMoney;
        private bool _levelIsPassed;

        public int CurrentLevel => _currentLevel;
        public bool LevelIsPassed => _levelIsPassed;

        public ProgressionModel()
        {
            _currentLevel = 1;
            _moneyToIncreaseLevel = 20;
        }

        public void IncreaseLevel()
        {
            _currentLevel++;
            _moneyToIncreaseLevel *= _currentLevel;
            _levelIsPassed = false;
        }

        public void IncreaseMoney(int amount = 1)
        {
            _currentMoney += amount;

            if (_currentMoney >= _moneyToIncreaseLevel)
            {
                _levelIsPassed = true;
            }
        }
    }
}