using UnityEngine;
using Upgrades.Components;

namespace LevelProgression.Upgrades.Upgrades.Base
{
    public abstract class Upgrade
    {
        private UpgradeSO _so;
        
        protected object buff;
        
        public UpgradeType Type => _so.Type;
        public Color Color => _so.Color;
        public object Buff => buff;
        
        public bool IsPaid { get; protected set; }
        public bool IsAd { get; protected set; } = false;
        
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Upgrade(UpgradeSO so)
        {
            _so = so;
        }

        public abstract void DoubleBuff();

        protected void SetName(string newName)
        {
            Name = newName;
        }

        protected void SetDescription(string description)
        {
            Description = description;
        }
    }
}