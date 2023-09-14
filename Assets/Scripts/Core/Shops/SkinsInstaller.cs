using Core.Shops.SkinShop;
using Core.Shops.SkinShop.Presenter;
using Core.Shops.SkinShop.View;
using Player.Skin;
using Player.Skin.Presenter;
using Player.Skin.View;
using UnityEngine;

namespace Core.Shops
{
    public class SkinsInstaller : MonoBehaviour
    {
        [SerializeField] private SkinShopSettings _skinShopSettings;
        [SerializeField] private SkinShopView _skinShopView;
        [SerializeField] private SkinSettings _skinSettings;
        [SerializeField] private SkinView _skinView;

        private SkinShopPresenter _skinShop;
        private SkinPresenter _skin;

        public void Construct()
        {
            _skin = new(_skinView, _skinSettings);
            _skinShop = new(_skinShopView, _skinShopSettings);

            _skinShop.Selected += _skin.Set;
        }

        public void Disable()
        {
            _skinShop.Selected -= _skin.Set;
        }
    }
}