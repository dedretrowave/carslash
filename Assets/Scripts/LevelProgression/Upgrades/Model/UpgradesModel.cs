using System.Collections.Generic;
using LevelProgression.Upgrades.Components;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Model
{
    public class UpgradesModel
    {
        private const string ResourcesPath = "Upgrades";
        
        private List<Upgrade> _upgrades;
        private UpgradesSettings _settings;

        public UpgradesModel(UpgradesSettings settings)
        {
            _upgrades = new(Resources.LoadAll<Upgrade>(ResourcesPath));
            _settings = settings;
        }

        public List<Upgrade> GetRandom()
        {
            List<Upgrade> upgrades = new();

            int i = 0;

            while (i < _settings.UpgradesCount)
            {
                int randomAdProc = Random.Range(0, 100);
                bool isPaid = false;
                bool isAd = false;

                if (randomAdProc < _settings.ChanceOfAdUpgrade)
                {
                    isAd = true;
                } else if (randomAdProc < _settings.ChanceOfPaidUpgrade)
                {
                    isPaid = true;
                }
                
                Upgrade upgrade = _upgrades[Random.Range(0, _upgrades.Count)];
                upgrade.Construct();

                if (upgrades.Contains(upgrade))
                {
                    continue;
                }

                if (isAd)
                {
                    upgrade.TripleBuff();
                } else if (isPaid)
                {
                    upgrade.DoubleBuff();
                }
                
                upgrades.Add(upgrade);
                i++;
            }

            return upgrades;
        }
    }
}