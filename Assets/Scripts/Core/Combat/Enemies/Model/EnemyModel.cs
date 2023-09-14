using System;

namespace Combat.Enemies.Model
{
    public class EnemyModel
    {
        private float _health;

        public float Health => _health;

        public event Action OutOfHealth;

        public EnemyModel(int maxHealth = 10)
        {
            _health = maxHealth;
        }

        public void ReduceHealth(float amount)
        {
            float newHealth = _health - amount;

            if (newHealth <= 0)
            {
                OutOfHealth?.Invoke();
                _health = 0;
                return;
            }

            _health = newHealth;
        }
    }
}