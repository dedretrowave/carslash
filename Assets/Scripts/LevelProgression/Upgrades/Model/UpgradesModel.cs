using System.Collections.Generic;
using LevelProgression.Upgrades.Components;
using LevelProgression.Upgrades.Upgrades;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Model
{
    public class UpgradesModel
    {
        private const string ResourcesPath = "Upgrades";
        
        private List<UpgradeSO> _upgrades;
        private UpgradesSettings _settings;
        private UpgradesFactory _factory;

        public UpgradesModel(UpgradesSettings settings)
        {
            _upgrades = new(Resources.LoadAll<UpgradeSO>(ResourcesPath));
            _settings = settings;
            _factory = new();
        }

        public List<Upgrade> GetRandom()
        {
            List<Upgrade> upgrades = new();

            int i = 0;
            
            int randomAdProc = Random.Range(0, 100);
            bool isAdSpawn = randomAdProc < _settings.ChanceOfAdUpgrade;

            while (i < _settings.UpgradesCount)
            {
                UpgradeSO upgradeSO = _upgrades[Random.Range(0, _upgrades.Count)];

                Upgrade upgrade = _factory.Create(upgradeSO);

                if (upgrades.Find(existingUpgrade
                        => existingUpgrade.Type == upgrade.Type) != null)
                {
                    continue;
                }

                if (isAdSpawn)
                {
                    upgrade.DoubleBuff();
                    isAdSpawn = false;
                }

                upgrades.Add(upgrade);
                i++;
            }
            
            return upgrades;
        }
    }

    internal class UpgradesFactory
    {
        public Upgrade Create(UpgradeSO so)
        {
            switch (so)
            {
                case WeaponUpgradeSO:
                    return new WeaponUpgrade((WeaponUpgradeSO)so);
                case PropertyUpgradeSO:
                    return new PropertyUpgrade((PropertyUpgradeSO)so);
                default:
                    return null;
            }
        }
    }
}