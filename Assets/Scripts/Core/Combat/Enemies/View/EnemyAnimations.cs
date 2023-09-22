using UnityEngine;

namespace Core.Combat.Enemies.View
{
    public class EnemyAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _chanceOfCrawl = 50f;

        private bool _isCrawling;
        
        private static readonly int IsCrawlingKey = Animator.StringToHash("IsCrawling");
        private static readonly int IsDeadKey = Animator.StringToHash("IsDead");

        private void Awake()
        {
            _isCrawling = Random.Range(0, 100f) < _chanceOfCrawl;
            _animator.SetBool(IsCrawlingKey, _isCrawling);
        }

        public void PlayDead()
        {
            _animator.SetBool(IsDeadKey, true);
        }
    }
}