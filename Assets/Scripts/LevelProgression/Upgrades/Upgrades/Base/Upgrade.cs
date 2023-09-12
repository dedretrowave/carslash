using UnityEngine;
using Upgrades.Components;

namespace LevelProgression.Upgrades.Upgrades.Base
{
    public abstract class Upgrade : ScriptableObject
    {
        [Header("UI")]
        [SerializeField] private Color _color;

        [Header("Type")]
        [SerializeField] private UpgradeType type;

        protected object buff;

        public UpgradeType Type => type;
        public object Buff => buff;
        
        public bool IsPaid { get; private set; }
        public bool IsAd { get; private set; }

        public Color Color => _color;
        public string Name { get; private set; }
        public string Description { get; private set; }

        public abstract void Construct();

        public void DoubleBuff()
        {
            IsPaid = true;
        }

        public void TripleBuff()
        {
            IsAd = true;
        }

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