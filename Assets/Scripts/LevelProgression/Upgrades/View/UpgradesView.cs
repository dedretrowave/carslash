using System;
using System.Collections.Generic;
using LevelProgression.Upgrades.Components.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.View
{
    public class UpgradesView : MonoBehaviour
    {
        [SerializeField] private RectTransform _wrapper;
        [SerializeField] private RectTransform _upgradesParent;
        [SerializeField] private UpgradeUI _upgradesPrefab;

        private List<UpgradeUI> _upgradeUis = new();

        public event Action<Upgrade> Selected;

        public void Show(List<Upgrade> upgrades)
        {
            _wrapper.gameObject.SetActive(true);
            
            foreach (Upgrade upgrade in upgrades)
            {
                UpgradeUI upgradeUI = Instantiate(_upgradesPrefab, _upgradesParent);
                
                upgradeUI.Display(upgrade);
                upgradeUI.Clicked += OnSelected;
                _upgradeUis.Add(upgradeUI);
            }
        }

        private void OnSelected(Upgrade upgrade)
        {
            Selected?.Invoke(upgrade);
        }

        public void Remove()
        {
            _wrapper.gameObject.SetActive(false);
            
            foreach (UpgradeUI upgradeUi in _upgradeUis)
            {
                upgradeUi.Clicked -= OnSelected;
                Destroy(upgradeUi.gameObject);
            }
        }
    }
}