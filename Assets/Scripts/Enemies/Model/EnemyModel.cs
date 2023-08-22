using System;

namespace Enemies.Model
{
    public class EnemyModel
    {
        private int _health;

        public int Health => _health;

        public Action OnOutOfHealth;

        public EnemyModel(int maxHealth = 10)
        {
            _health = maxHealth;
        }

        public void ReduceHealth(int amount)
        {
            int newHealth = _health - amount;

            if (newHealth <= 0)
            {
                OnOutOfHealth?.Invoke();
                _health = 0;
                return;
            }

            _health = newHealth;
        }
    }
}