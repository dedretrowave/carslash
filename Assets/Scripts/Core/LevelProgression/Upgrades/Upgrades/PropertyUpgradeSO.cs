using System.Collections.Generic;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Upgrades
{
    [CreateAssetMenu(fileName = "Property Upgrade", order = 1)]
    public class PropertyUpgradeSO : UpgradeSO
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _descriptionAddition;
        [SerializeField] private List<float> _increaseAmountVariants;

        public string Name => _name;
        public string Description => _description;
        public string DescriptionAddition => _descriptionAddition;

        public float GetIncreasedAmount()
        {
            return _increaseAmountVariants[Random.Range(0, _increaseAmountVariants.Count)];
        }
    }
}