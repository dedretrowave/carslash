using System;
using Core.Shops.SkinShop.Model;
using Core.Shops.SkinShop.View;
using Player.Skin.Components;

namespace Core.Shops.SkinShop.Presenter
{
    public class SkinShopPresenter
    {
        private SkinShopModel _model;

        private SkinShopView _view;

        private Skin _skinToPurchase;

        public event Action<Skin> Selected;
        public event Action<int> TriedPurchase; 

        public SkinShopPresenter(SkinShopView view, SkinShopSettings settings)
        {
            _model = new(settings);

            _view = view;
            
            _view.Construct(settings);

            _view.Selected += OnSelected;
            _view.TriedPurchase += TryPurchase;
            _view.SkinToPurchaseSelected += OnPurchaseSkinSelected;
        }

        ~SkinShopPresenter()
        {
            _view.Selected -= OnSelected;
            _view.TriedPurchase -= TryPurchase;
            _view.SkinToPurchaseSelected -= OnPurchaseSkinSelected;
        }
        
        public void Purchase()
        {
            _model.MarkPurchased(_skinToPurchase);
            _view.DisplayWindow(_model.GetIsPurchased(_skinToPurchase));
        }

        private void OnPurchaseSkinSelected(Skin skin)
        {
            bool isPurchased = _model.GetIsPurchased(skin);
            int price = _model.GetPrice(skin);
            _view.DisplayWindow(isPurchased, price);
        }

        private void TryPurchase(Skin skin)
        {
            _skinToPurchase = skin;
            
            int price = _model.GetPrice(skin);
            
            TriedPurchase?.Invoke(price);
        }

        private void OnSelected(Skin skin)
        {
            _model.MarkSelected(skin);
            Selected?.Invoke(skin);
        }
    }
}