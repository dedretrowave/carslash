using System;
using UnityEngine;

namespace Player.Health.Model
{
    public class HealthModel
    {
        private int _count;
        private int _maxCount;

        public int Count => _count;

        public event Action OnOutOfHealth;

        public HealthModel(int defaultCount, int maxCount = 10)
        {
            _count = defaultCount;
            _maxCount = maxCount;
        }

        public void Add(int count = 1)
        {
            int newCount = _count + count;

            if (newCount >= _maxCount)
            {
                _count = _maxCount;
                return;
            }

            _count = newCount;
        }

        public void Reduce(int count = 1)
        {
            int newCount = _count - count;

            if (newCount <= 0)
            {
                Debug.Log("OUT OF HEALTH");
                _count = 0;
                OnOutOfHealth?.Invoke();
                return;
            }

            _count = newCount;
        }
    }
}