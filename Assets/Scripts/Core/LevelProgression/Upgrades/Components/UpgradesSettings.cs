using System;
using UnityEngine;

namespace LevelProgression.Upgrades.Components
{
    [Serializable]
    public class UpgradesSettings
    {
        [SerializeField] private int _upgradesCount = 5;
        [SerializeField] private int _paidUpgradesCount = 1;
        [SerializeField] private int _adUpgradesCount = 1;
        [SerializeField] private float _chanceOfPaidUpgrade = 45;
        [SerializeField] private float _chanceOfAdUpgrade = 20;
        
        public int UpgradesCount => _upgradesCount;
        public int PaidUpgradesCount => _paidUpgradesCount;
        public int ADUpgradesCount => _adUpgradesCount;
        public float ChanceOfPaidUpgrade => _chanceOfPaidUpgrade;
        public float ChanceOfAdUpgrade => _chanceOfAdUpgrade;
    }
}