using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Shops.SkinShop.Components
{
    public class PurchaseWindow : MonoBehaviour
    {
        [SerializeField] private Button _purchase;
        [SerializeField] private Button _select;
        [SerializeField] private TextMeshProUGUI _purchaseLabel;

        public event Action Purchased;
        public event Action Selected;

        private void Awake()
        {
            _purchase.onClick.AddListener(Purchase);
            _select.onClick.AddListener(Select);
        }

        public void SetPrice(int price)
        {
            _purchaseLabel.text = price.ToString();
        }

        public void SwitchButtons(bool isPurchased)
        {
            if (isPurchased)
            {
                _purchase.gameObject.SetActive(false);
                _select.gameObject.SetActive(true);
            }
            else
            {
                _purchase.gameObject.SetActive(true);
                _select.gameObject.SetActive(false);
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Purchase()
        {
            Purchased?.Invoke();
        }

        private void Select()
        {
            Selected?.Invoke();
        }
    }
}