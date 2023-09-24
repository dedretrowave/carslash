using UnityEngine;

namespace Core.Combat.Weapon.Arms.VFX
{
    public class ArmsVFX : MonoBehaviour
    {
        [SerializeField] private Base.Arms _arms;
        [SerializeField] private ParticleSystem _shootParticles;

        private void Awake()
        {
            _shootParticles.Stop(true);
            _arms.Shot += OnShoot;
        }

        private void OnDisable()
        {
            _arms.Shot -= OnShoot;
        }
        
        private void OnShoot()
        {
            _shootParticles.Play(true);
        }
    }
}