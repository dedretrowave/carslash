using Combat.Weapon.Arms.Base;
using LevelProgression.Upgrades.Components.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Components
{
    [CreateAssetMenu(fileName = "Weapon Upgrade", order = 2)]
    public class WeaponUpgrade : Upgrade
    {
        [SerializeField] private Arms _newArms;

        public Arms Arms => _newArms;
        public override void Construct()
        {
            
        }
    }
}