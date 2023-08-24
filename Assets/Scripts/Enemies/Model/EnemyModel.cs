using System;

namespace Enemies.Model
{
    public class EnemyModel
    {
        private float _health;

        public float Health => _health;

        public Action OnOutOfHealth;

        public EnemyModel(int maxHealth = 10)
        {
            _health = maxHealth;
        }

        public void ReduceHealth(float amount)
        {
            float newHealth = _health - amount;

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