using System;
using LevelProgression.Upgrades.Components.Base;
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
        [SerializeField] private Button _button;

        private Upgrade _upgrade;

        public event Action<Upgrade> Clicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(_upgrade);
        }

        public void Display(Upgrade upgrade)
        {
            _upgrade = upgrade;
            
            _name.text = upgrade.Name;
            _description.text = upgrade.Description;
            _bg.color = upgrade.Color;
        }
    }
}