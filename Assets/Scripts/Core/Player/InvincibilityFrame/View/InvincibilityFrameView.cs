using System;
using System.Collections;
using UnityEngine;

namespace Core.Player.InvincibilityFrame.View
{
    public class InvincibilityFrameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int PlayKey = Animator.StringToHash("Play");

        public event Action End;

        public void Play(float duration)
        {
            StartCoroutine(PlayRoutine(duration));
        }

        private IEnumerator PlayRoutine(float duration)
        {
            _animator.SetBool(PlayKey, true);

            yield return new WaitForSeconds(duration);

            _animator.SetBool(PlayKey,false);
            End?.Invoke();
        }
    }
}