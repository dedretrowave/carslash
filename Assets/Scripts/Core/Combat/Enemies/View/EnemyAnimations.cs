using UnityEngine;

namespace Core.Combat.Enemies.View
{
    public class EnemyAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private int _walkingAnimationsCount;

        private static readonly int WalkingIndexKey = Animator.StringToHash("WalkingIndex");
        private static readonly int IsDeadKey = Animator.StringToHash("IsDead");
        private static readonly int TakeDamageKey = Animator.StringToHash("TakeDamage");

        private void Awake()
        {
            int index = Random.Range(0, _walkingAnimationsCount);
            _animator.SetInteger(WalkingIndexKey, index);
        }

        public void PlayHurt()
        {
            _animator.SetTrigger(TakeDamageKey);
        }

        public void PlayDead()
        {
            _animator.SetBool(IsDeadKey, true);
        }
    }
}