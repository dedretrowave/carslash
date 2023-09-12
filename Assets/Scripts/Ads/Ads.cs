using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Ads
{
    public class Ads : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        private bool _isReady = true;
        
        [DllImport("__Internal")]
        private static extern void ShowAdExternal();

        [DllImport("__Internal")]
        private static extern void ShowRewardedExternal();

        private void Awake()
        {
        }

        public void ShowRewarded()
        {
#if  !UNITY_EDITOR
            ShowRewardedExternal();      
#endif
        }

        public void ShowAd()
        {
            if (!_isReady)
            {
                InvokeAdWatched();
                return;
            }
            
            StartCoroutine(FreezeAds());
            
#if  !UNITY_EDITOR
        ShowAdExternal();
#else
            Debug.Log("Very interesting Ad!");
#endif
        }

        private IEnumerator FreezeAds()
        {
            _isReady = false;
            
            yield return new WaitForSeconds(65);

            _isReady = true;
        }

        public void InvokeAdWatched()
        {
            // _eventBus.TriggerEvent(EventName.ON_AD_WATCHED);
        }

        public void InvokeRewardedWatched()
        {
            // _eventBus.TriggerEvent(EventName.ON_REWARDED_WATCHED);
        }
    }
}