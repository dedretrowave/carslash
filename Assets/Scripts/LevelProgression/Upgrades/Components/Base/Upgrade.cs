using UnityEngine;

namespace LevelProgression.Upgrades.Components.Base
{
    public abstract class Upgrade : ScriptableObject
    {
        [Header("UI")]
        [SerializeField] private Color _color;
        [SerializeField] private string _name;
        [SerializeField] protected string _descriptionBase;

        protected string _description;
        
        public Color Color => _color;
        public string Name => _name;
        public string Description => _description;

        public abstract void Construct();
    }
}