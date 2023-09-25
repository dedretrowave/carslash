using System;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Upgrades
{
    public class PropertyUpgrade : Upgrade
    {
        private PropertyUpgradeSO _so;
        
        private float _increaseAmount;
        
        public float IncreaseAmount => _increaseAmount;

        public PropertyUpgrade(PropertyUpgradeSO so) : base(so)
        {
            _so = so;
            _increaseAmount = _so.GetIncreasedAmount();
            buff = _increaseAmount;

            base.SetName(_so.Name);
            SetDescription();
        }

        public override void DoubleBuff()
        {
            IsAd = true;
            _increaseAmount = Mathf.Round(_increaseAmount * 1.5f);
            buff = _increaseAmount;
            SetDescription();
        }
        
        private void SetDescription()
        {
            base.SetDescription($"{_so.Description} {_increaseAmount} {_so.DescriptionAddition}");
        }
    }
}