using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Economics.Wallet.View
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private LayerMask _moneyLayerMask;

        private const float MoneyTweenSpeedInSecs = .3f;
        private const int MoneyDestroyDelayInMilliSecs = 400;

        public event Action OnPickup;

        public void SetMoney(int amount)
        {
            _label.text = amount.ToString();
        }

        private async void DestroyMoney(Collider money)
        {
            await Task.Delay(MoneyDestroyDelayInMilliSecs);
            money.transform.DOKill();
            Destroy(money.gameObject);
        }

        public void CollectMoney(Collider other)
        {
            if ((_moneyLayerMask.value & (1 << other.gameObject.layer)) == 0) return;

            other.transform.SetParent(transform);
            other.transform.DOLocalMove(Vector3.zero, MoneyTweenSpeedInSecs);
            DestroyMoney(other);
            OnPickup?.Invoke();
        }
    }
}