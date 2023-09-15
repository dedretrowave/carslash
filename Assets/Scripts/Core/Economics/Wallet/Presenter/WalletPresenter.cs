using System;
using Economics.Wallet.Model;
using Economics.Wallet.View;

namespace Core.Economics.Wallet.Presenter
{
    public class WalletPresenter
    {
        private WalletModel _model;

        private WalletView _view;

        public event Action<int> MoneyIncrease;

        public WalletPresenter(WalletView view)
        {
            _view = view;

            _model = new();
            
            _view.SetMoney(_model.Amount);

            _view.Pickup += OnPickup;
        }

        ~WalletPresenter()
        {
            _view.Pickup -= OnPickup;
        }

        public void Reduce(int amount)
        {
            _model.Reduce(amount);
            _view.SetMoney(_model.Amount);
        }

        private void OnPickup()
        {
            _model.Add();
            _view.SetMoney(_model.Amount);
            MoneyIncrease?.Invoke(1);
        }
    }
}