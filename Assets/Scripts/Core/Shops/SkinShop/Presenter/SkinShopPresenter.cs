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

        public event Action<Skin> Selected; 

        public SkinShopPresenter(SkinShopView view, SkinShopSettings settings)
        {
            _model = new(settings);

            _view = view;
            
            _view.Construct(settings);

            _view.Selected += OnSelected;
            _view.Purchased += OnPurchased;
            _view.SkinToPurchaseSelected += OnPurchaseSkinSelected;
        }

        ~SkinShopPresenter()
        {
            _view.Selected -= OnSelected;
            _view.Purchased -= OnPurchased;
            _view.SkinToPurchaseSelected -= OnPurchaseSkinSelected;
        }

        private void OnPurchaseSkinSelected(Skin skin)
        {
            bool isPurchased = _model.GetIsPurchased(skin);
            int price = _model.GetPrice(skin);
            _view.DisplayWindow(isPurchased, price);
        }

        private void OnPurchased(Skin skin)
        {
            _model.MarkPurchased(skin);
            _view.DisplayWindow(_model.GetIsPurchased(skin));
        }

        private void OnSelected(Skin skin)
        {
            _model.MarkSelected(skin);
            Selected?.Invoke(skin);
        }
    }
}