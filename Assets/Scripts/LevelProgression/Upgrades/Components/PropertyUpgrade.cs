using System.Collections.Generic;
using LevelProgression.Upgrades.Components.Base;
using UnityEngine;
using Upgrades.Components;

namespace LevelProgression.Upgrades.Components
{
    [CreateAssetMenu(fileName = "Property Upgrade", order = 1)]
    public class PropertyUpgrade : Upgrade
    {
        [SerializeField] private string _descriptionAddition;
        [SerializeField] private UpgradeType _type;
        [SerializeField] private List<float> _increaseAmountVariants;

        private float _increaseAmount;
        
        public UpgradeType Type => _type;
        public float IncreaseAmount => _increaseAmount;

        public override void Construct()
        {
            _increaseAmount = _increaseAmountVariants
                [Random.Range(0, _increaseAmountVariants.Count)];

            _description = $"{_descriptionBase} {_increaseAmount}{_descriptionAddition}";
        }
    }
}