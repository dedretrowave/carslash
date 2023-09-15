using System.Collections.Generic;
using Player.Health.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Health.View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Heart _heartPrefab;
        [SerializeField] private LayoutGroup _layout;

        private List<Heart> _hearts = new();

        public void DrawAndFill(int count, int maxCount)
        {
            Draw(maxCount);
            Fill(count);
        }

        private void Draw(int count = 1)
        {
            _hearts.ForEach(heart => Destroy(heart.gameObject));
            _hearts.Clear();
            
            for (int i = 0; i < count; i++)
            {
                _hearts.Add(
                Instantiate(_heartPrefab, _layout.transform)
                    );
            }
        }

        private void Fill(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                _hearts[i].Fill();
            }
        }
    }
}