using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Player.Health.View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _heart;
        [SerializeField] private LayoutGroup _layout;

        public void Add(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(_heart, _layout.transform);
            }
        }

        public void Reduce(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(_layout.transform.GetChild(_layout.transform.childCount - 1).gameObject);
            }
        }
    }
}