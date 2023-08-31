using UnityEngine;
using UnityEngine.Events;

namespace Helpers
{
    public class ColliderEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collision> _onCollisionEnter;
        [SerializeField] private UnityEvent<Collision> _onCollisionExit;
        [SerializeField] private UnityEvent<Collision> _onCollisionStay;
        
        [SerializeField] private UnityEvent<Collider> _onTriggerEnter;
        [SerializeField] private UnityEvent<Collider> _onTriggerExit;
        [SerializeField] private UnityEvent<Collider> _onTriggerStay;

        private void OnCollisionEnter(Collision collision)
        {
            _onCollisionEnter?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            _onCollisionExit?.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            _onCollisionStay?.Invoke(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            _onTriggerEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _onTriggerExit?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            _onTriggerStay?.Invoke(other);
        }
    }
}