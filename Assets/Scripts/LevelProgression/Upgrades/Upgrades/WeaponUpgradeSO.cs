using System.Collections.Generic;
using Combat.Weapon.Arms.Base;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Upgrades
{
    [CreateAssetMenu(fileName = "Weapon Upgrade", order = 2)]
    public class WeaponUpgradeSO : UpgradeSO
    {
        [SerializeField] private List<Arms> _basicArms;
        [SerializeField] private List<Arms> _advancedTierArms;

        public Arms GetRandomBasic()
        {
            return _basicArms[Random.Range(0, _basicArms.Count)];
        }
        
        public Arms GetRandomAdvanced()
        {
            return _advancedTierArms[Random.Range(0, _advancedTierArms.Count)];
        }
    }
}