using System;

namespace Economics.Wallet.Model
{
    public class WalletModel
    {
        private int _amount;

        public int Amount => _amount;

        public WalletModel()
        {
            // TODO: ADD SAVE
            _amount = 10000;
        }

        public void Add(int amount = 1)
        {
            _amount += amount;
        }

        public void Reduce(int amount = 1)
        {
            int newAmount = _amount - amount;

            if (newAmount <= 0)
            {
                _amount = 0;
                throw new Exception("No money");
            }

            _amount = newAmount;
        }
    }
}