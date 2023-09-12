using System;
using UnityEngine;

namespace LevelProgression.Progression.Settings
{
    [Serializable]
    public class ProgressionSettings
    {
        [SerializeField] private int _moneyToIncreaseLevelBase = 10;
        
        public int MoneyToIncreaseLevelBase => _moneyToIncreaseLevelBase;
    }
}