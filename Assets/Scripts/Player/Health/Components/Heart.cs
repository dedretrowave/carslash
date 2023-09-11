using UnityEngine;
using UnityEngine.UI;

namespace Player.Health.Components
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private Sprite _filled;
        [SerializeField] private Sprite _empty;

        [SerializeField] private Image _image;

        public bool IsFilled { get; private set; }

        private void Awake()
        {
            Empty();
        }

        public void Fill()
        {
            _image.sprite = _filled;
            IsFilled = true;
        }

        public void Empty()
        {
            _image.sprite = _empty;
            IsFilled = false;
        }
    }
}