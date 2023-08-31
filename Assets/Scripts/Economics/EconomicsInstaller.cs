using System;
using Economics.Wallet.Presenter;
using Economics.Wallet.View;
using UnityEngine;

namespace Economics
{
    public class EconomicsInstaller : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;

        private WalletPresenter _wallet;

        private void Awake()
        {
            _wallet = new(_walletView);
        }
    }
}