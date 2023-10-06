using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Economics.Wallet.View
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private LayerMask _moneyLayerMask;

        private const float MoneyTweenSpeedInSecs = 1f;
        private const int MoneyDestroyDelayInMilliSecs = 400;

        public event Action Pickup;

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

        public void OnTriggerEnter(Collider other)
        {
            if ((_moneyLayerMask.value & (1 << other.gameObject.layer)) == 0) return;

            other.transform.SetParent(transform);
            other.transform.DOLocalMove(Vector3.zero, MoneyTweenSpeedInSecs);
            DestroyMoney(other);
            Pickup?.Invoke();
        }
    }
}