using LevelProgression.Progression.Settings;

namespace Core.LevelProgression.Progression.Model
{
    public class ProgressionModel
    {
        private int _currentLevel;
        private int _progressCap;
        private int _progressCapBase;
        private int _currentProgress;
        private bool _levelIsPassed;

        public int CurrentLevel => _currentLevel;
        public bool LevelIsPassed => _levelIsPassed;
        public int CurrentProgress => _currentProgress;
        public int ProgressCap => _progressCap;

        public ProgressionModel(ProgressionSettings settings)
        {
            _currentLevel = 1;
            _progressCap = _progressCapBase = settings.MoneyToIncreaseLevelBase;
        }

        public void IncreaseLevel()
        {
            _currentLevel++;
            _progressCap = _progressCapBase * _currentLevel;
            _currentProgress = 0;
            _levelIsPassed = false;
        }

        public void IncreaseProgress(int amount = 1)
        {
            _currentProgress += amount;

            if (_currentProgress >= _progressCap)
            {
                _levelIsPassed = true;
            }
        }
    }
}