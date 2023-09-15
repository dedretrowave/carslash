using UnityEngine;
using UnityEngine.UI;

namespace Core.LevelProgression.Progression.View
{
    public class ProgressionView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Fill(float value)
        {
            _slider.value = value;
        }
    }
}