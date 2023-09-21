using System;
using System.Collections.Generic;
using Core.Player.Skin.Components;
using Core.Shops.SkinShop.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Shops.SkinShop.View
{
    public class SkinShopView : MonoBehaviour
    {
        [SerializeField] private PurchaseWindow _purchaseWindow;

        private SkinPlace _currentPlace;

        private List<SkinPlace> _places = new();

        public event Action<Skin> Selected;
        public event Action<Skin> TriedPurchase; 
        public event Action<Skin> SkinToPurchaseSelected; 

        private void Start()
        {
            _purchaseWindow.Selected += Select;
            _purchaseWindow.Purchased += TryPurchase;
        }
        
        private void OnDisable()
        {
            _purchaseWindow.Selected -= Select;
            _purchaseWindow.Purchased -= TryPurchase;
            
            foreach (SkinPlace place in _places)
            {
                place.PlayerEnter -= OnEnter;
                place.PlayerExit -= OnExit;
            }
        }

        public void Construct(SkinShopSettings settings)
        {
            foreach ((SkinPlace place, int _) in settings.Places)
            {
                _places.Add(place);
                place.PlayerEnter += OnEnter;
                place.PlayerExit += OnExit;
            }
        }

        private void OnEnter(SkinPlace place)
        {
            _currentPlace = place;
            SkinToPurchaseSelected?.Invoke(place.Skin);
        }

        private void OnExit()
        {
            HideWindow();
            _currentPlace = null;
        }

        public void DisplayWindow(bool isPurchased, int price = 0)
        {
            _purchaseWindow.Show();
            _purchaseWindow.SwitchButtons(isPurchased);
            _purchaseWindow.SetPrice(price);
            _purchaseWindow.transform.position = _currentPlace.transform.position + Vector3.up * 5f;
        }

        private void HideWindow()
        {
            _purchaseWindow.Hide();
        }

        private void Select()
        {
            Selected?.Invoke(_currentPlace.Skin);
        }

        private void TryPurchase()
        {
            TriedPurchase?.Invoke(_currentPlace.Skin);
        }
    }
}