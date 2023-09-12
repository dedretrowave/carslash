using System;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;

namespace LevelProgression.Upgrades.View
{
    public class AdUpgradeUI : UpgradeUI
    {
        public event Action<Upgrade> Clicked; 

        public new void OnClick()
        {
            Debug.Log("AD CLICK");
            Clicked?.Invoke(upgrade);
        }
    }
}