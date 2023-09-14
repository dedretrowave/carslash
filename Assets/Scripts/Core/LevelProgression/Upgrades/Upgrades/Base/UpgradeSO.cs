using UnityEngine;
using Upgrades.Components;

namespace LevelProgression.Upgrades.Upgrades.Base
{
    public abstract class UpgradeSO : ScriptableObject
    {
        [Header("UI")]
        [SerializeField] private Color _color;

        [Header("Type")]
        [SerializeField] private UpgradeType type;

        protected object buff;

        public UpgradeType Type => type;
        public object Buff => buff;

        public Color Color => _color;
    }
}