using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class AnimationEndEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _event;
        
        public void Invoke()
        {
            _event.Invoke();
        }
    }
}