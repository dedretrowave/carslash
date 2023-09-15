using System;
using Core.Economics.Wallet.Presenter;
using Core.Shops.SkinShop;
using Core.Shops.SkinShop.Presenter;
using Core.Shops.SkinShop.View;
using Economics.Wallet.View;
using Player.Skin;
using Player.Skin.Presenter;
using Player.Skin.View;
using UnityEngine;

namespace Core.Shops
{
    public class ShopsInstaller : MonoBehaviour
    {
        [Header("SHOPS")]
        [SerializeField] private SkinShopSettings _skinShopSettings;
        [SerializeField] private SkinShopView _skinShopView;
        [Header("PURCHASES")]
        [SerializeField] private SkinSettings _skinSettings;
        [SerializeField] private SkinView _skinView;
        [Header("WALLET")]
        [SerializeField] private WalletView _walletView;

        private SkinShopPresenter _skinShop;
        private SkinPresenter _skin;
        private WalletPresenter _wallet;

        public void Construct()
        {
            _wallet = new(_walletView);
            _skin = new(_skinView, _skinSettings);
            _skinShop = new(_skinShopView, _skinShopSettings);

            _skinShop.Selected += _skin.Set;
            _skinShop.TriedPurchase += OnTryPurchase;
        }

        public void Disable()
        {
            _skinShop.Selected -= _skin.Set;
            _skinShop.TriedPurchase -= OnTryPurchase;
        }

        private void OnTryPurchase(int price)
        {
            try
            {
                _wallet.Reduce(price);
                _skinShop.Purchase();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}