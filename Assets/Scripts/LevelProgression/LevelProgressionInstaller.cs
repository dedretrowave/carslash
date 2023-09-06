using System;
using Economics.Wallet.Presenter;
using Economics.Wallet.View;
using LevelProgression.Progression.Presenter;
using UnityEngine;

namespace LevelProgression
{
    public class LevelProgressionInstaller : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;

        private WalletPresenter _wallet;
        private ProgressionPresenter _progression;

        public event Action LevelPassed;

        private void Awake()
        {
            _wallet = new(_walletView);
            _progression = new();

            _wallet.MoneyIncrease += _progression.IncreaseMoney;
            _progression.LevelPassed += OnLevelPassed;
        }

        private void OnDisable()
        {
            _wallet.MoneyIncrease -= _progression.IncreaseMoney;
            _progression.LevelPassed -= OnLevelPassed;
        }

        private void OnLevelPassed()
        {
            LevelPassed?.Invoke();
        }
    }
}