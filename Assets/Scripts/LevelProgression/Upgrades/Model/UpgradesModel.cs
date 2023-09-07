using System.Collections.Generic;
using LevelProgression.Upgrades.Components.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Model
{
    public class UpgradesModel
    {
        private const string ResourcesPath = "Upgrades";
        private List<Upgrade> _upgrades;

        public UpgradesModel()
        {
            _upgrades = new(Resources.LoadAll<Upgrade>(ResourcesPath));
        }

        public List<Upgrade> GetRandom()
        {
            List<Upgrade> upgrades = new();

            int i = 0;

            while (i < 3)
            {
                Upgrade upgrade = _upgrades[Random.Range(0, _upgrades.Count)];
                upgrade.Construct();

                if (upgrades.Contains(upgrade))
                {
                    continue;
                }
                
                upgrades.Add(upgrade);
                i++;
            }

            return upgrades;
        }
    }
}