using System;
using Core.Combat.Enemies.Components;

namespace Core.Combat.Enemies.Model
{
    public class EnemyModel
    {
        private float _health;

        public float Health => _health;

        public event Action OutOfHealth;

        public EnemyModel(EnemySettings settings)
        {
            _health = settings.MaxHealth;
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