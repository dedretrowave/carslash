using Core.Shops.SkinShop;
using Core.Shops.SkinShop.Presenter;
using Core.Shops.SkinShop.View;
using Player.Skin;
using Player.Skin.Presenter;
using Player.Skin.View;
using UnityEngine;

namespace Core.Player
{
    public class PlayerVisualsInstaller : MonoBehaviour
    {
        [SerializeField] private SkinSettings _skinSettings;
        [SerializeField] private SkinView _skinView;
        [SerializeField] private SkinShopSettings _skinShopSettings;
        [SerializeField] private SkinShopView _skinShopView;

        private SkinPresenter _skin;
        private SkinShopPresenter _skinShopPresenter;

        public void Construct()
        {
            //TODO: REFACTOR TO MAKE STANDALONE MODULES FOR BOTH SCENES
            _skin = new(_skinView, _skinSettings);
            _skinShopPresenter = new(_skinShopView, _skinShopSettings);
            
            
        }
    }
}