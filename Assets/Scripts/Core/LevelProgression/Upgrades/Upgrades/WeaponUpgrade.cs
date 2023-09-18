using System;
using System.Collections.Generic;
using Core.Combat.Weapon.Arms.Base;
using LevelProgression.Upgrades.Upgrades.Base;

namespace LevelProgression.Upgrades.Upgrades
{
    public class WeaponUpgrade : Upgrade
    {
        private WeaponUpgradeSO _so;
        private Arms _selectedArms;

        public WeaponUpgrade(WeaponUpgradeSO so) : base(so)
        {
            _so = so;
            Setup(_so.GetRandomBasic());
        }
        
        public override void DoubleBuff()
        {
            IsAd = true;
            Setup(_so.GetRandomAdvanced());
        }

        private void Setup(Arms selectedArms)
        {
            buff = _selectedArms = selectedArms;
            base.SetName(_selectedArms.Name);
            base.SetDescription(_selectedArms.Description);
        }
    }
}