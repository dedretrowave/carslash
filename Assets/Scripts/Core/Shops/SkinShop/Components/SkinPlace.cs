using System;
using Player.Skin.Components;
using Player.Skin.View;
using UnityEngine;

namespace Core.Shops.SkinShop.Components
{
    public class SkinPlace : MonoBehaviour
    {
        [SerializeField] private Skin _skin;

        public Skin Skin => _skin;

        public event Action<SkinPlace> PlayerEnter;
        public event Action PlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out SkinView _)) return;
            
            PlayerEnter?.Invoke(this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out SkinView _)) return;
            
            PlayerExit?.Invoke();
        }
    }
}