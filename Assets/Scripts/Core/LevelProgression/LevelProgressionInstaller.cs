using System;
using DI;
using Economics.Wallet.Presenter;
using Economics.Wallet.View;
using LevelProgression.Progression.Presenter;
using LevelProgression.Progression.Settings;
using LevelProgression.Upgrades.Components;
using LevelProgression.Upgrades.Events;
using LevelProgression.Upgrades.Presenter;
using LevelProgression.Upgrades.Upgrades.Base;
using LevelProgression.Upgrades.View;
using UnityEngine;

namespace LevelProgression
{
    public class LevelProgressionInstaller : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private WalletView _walletView;
        [SerializeField] private UpgradesView _upgradesView;
        [Header("Settings")]
        [SerializeField] private UpgradesSettings _upgradesSettings;
        [SerializeField] private ProgressionSettings _progressionSettings;

        private UpgradesPresenter _upgrades;
        private WalletPresenter _wallet;
        private ProgressionPresenter _progression;
        private UpgradesEventManager _upgradeEventsManager;

        public event Action LevelEnded;
        public event Action<int> NewLevelStarted;

        public void Construct()
        {
            _wallet = new(_walletView);
            _progression = new(_progressionSettings);
            _upgrades = new(_upgradesSettings, _upgradesView);
            
            _upgradeEventsManager = new();
            
            DependencyContext.Dependencies.Add(
                new(
                    typeof(UpgradesEventManager),
                    () => _upgradeEventsManager));

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

        public void OnLose()
        {
            Debug.Log("LOSE(");
        }

        private void OnUpgradeSelected(Upgrade upgrade)
        {
            _upgradeEventsManager.Apply(upgrade);
            int levelIndex = _progression.IncreaseLevelAndReturn();
            NewLevelStarted?.Invoke(levelIndex);
        }

        private void OnLevelPassed()
        {
            LevelEnded?.Invoke();
            _upgrades.Show();
        }
    }
}