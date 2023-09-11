using System;
using Economics.Wallet.Presenter;
using Economics.Wallet.View;
using LevelProgression.Progression.Presenter;
using LevelProgression.Upgrades.Components.Base;
using LevelProgression.Upgrades.Presenter;
using LevelProgression.Upgrades.View;
using UnityEngine;

namespace LevelProgression
{
    public class LevelProgressionInstaller : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;
        [SerializeField] private UpgradesView _upgradesView;

        private UpgradesPresenter _upgrades;
        private WalletPresenter _wallet;
        private ProgressionPresenter _progression;

        public event Action LevelPassed;
        public event Action<Upgrade> UpgradeReceived;
        public event Action<int> NewLevelStarted;

        public void Construct()
        {
            _wallet = new(_walletView);
            _progression = new();
            _upgrades = new(_upgradesView);

            _wallet.MoneyIncrease += _progression.IncreaseMoney;
            _progression.LevelPassed += OnLevelPassed;
            _upgrades.Selected += OnUpgradeSelected;
        }

        public void Disable()
        {
            _wallet.MoneyIncrease -= _progression.IncreaseMoney;
            _progression.LevelPassed -= OnLevelPassed;
            _upgrades.Selected -= OnUpgradeSelected;
        }

        private void OnUpgradeSelected(Upgrade upgrade)
        {
            UpgradeReceived?.Invoke(upgrade);
            int levelIndex = _progression.IncreaseLevelAndReturn();
            NewLevelStarted?.Invoke(levelIndex);
        }

        private void OnLevelPassed()
        {
            LevelPassed?.Invoke();
            _upgrades.Show();
        }
    }
}