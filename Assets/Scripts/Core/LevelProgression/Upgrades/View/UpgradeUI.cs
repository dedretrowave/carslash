using System;
using LevelProgression.Upgrades.Upgrades.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelProgression.Upgrades.View
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _bg;

        protected Upgrade upgrade;

        public event Action<Upgrade> Clicked;

        public void OnClick()
        {
            Clicked?.Invoke(upgrade);
        }

        public void Display(Upgrade upgrade)
        {
            this.upgrade = upgrade;
            
            _name.text = upgrade.Name;
            _description.text = upgrade.Description;
            _bg.color = upgrade.Color;
        }
    }
}