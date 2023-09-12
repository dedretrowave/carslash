using System.Collections.Generic;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.Upgrades
{
    [CreateAssetMenu(fileName = "Property Upgrade", order = 1)]
    public class PropertyUpgrade : Upgrade
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _descriptionAddition;
        [SerializeField] private List<float> _increaseAmountVariants;

        private float _increaseAmount;
        
        public float IncreaseAmount => _increaseAmount;

        public override void Construct()
        {
            _increaseAmount = _increaseAmountVariants
                [Random.Range(0, _increaseAmountVariants.Count)];
            buff = _increaseAmount;

            base.SetName(_name);
            SetDescription();
        }

        public new void DoubleBuff()
        {
            base.DoubleBuff();
            _increaseAmount *= 2;
            buff = _increaseAmount;
            SetDescription();
        }

        public new void TripleBuff()
        {
            base.TripleBuff();
            _increaseAmount *= 3;
            buff = _increaseAmount;
            SetDescription();
        }

        private void SetDescription()
        {
            base.SetDescription($"{_description} {_increaseAmount} {_descriptionAddition}");
        }
    }
}