using System.Collections.Generic;
using Combat.Weapon.Arms.Base;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Upgrades
{
    [CreateAssetMenu(fileName = "Weapon Upgrade", order = 2)]
    public class WeaponUpgrade : Upgrade
    {
        [SerializeField] private List<Arms> _basicArms;
        [SerializeField] private List<Arms> _midTierArms;
        [SerializeField] private List<Arms> _topTierArms;

        private Arms _selectedArms;

        public override void Construct()
        {
             Setup(_basicArms[Random.Range(0, _basicArms.Count)]);
        }

        public new void DoubleBuff()
        {
            base.DoubleBuff();
            Setup(_midTierArms[Random.Range(0, _midTierArms.Count)]);
        }

        public new void TripleBuff()
        {
            base.TripleBuff();
            Setup(_topTierArms[Random.Range(0, _topTierArms.Count)]);
        }

        private void Setup(Arms selectedArms)
        {
            buff = _selectedArms = selectedArms;
            base.SetName(_selectedArms.Name);
            base.SetDescription(_selectedArms.Description);
        }
    }
}