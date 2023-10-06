using TMPro;
using UnityEngine;

namespace Core.LevelProgression.EndScreen.View
{
    public class EndScreenView : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _maxLevelLabel;

        public void SetMaxLevel(int maxLevel)
        {
            _maxLevelLabel.text = maxLevel.ToString();
        }

        public void Show()
        {
            _body.SetActive(true);
        }

        public void Hide()
        {
            _body.SetActive(false);
        }
    }
}