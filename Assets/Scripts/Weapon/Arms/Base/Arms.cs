using UnityEngine;

namespace Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        [SerializeField] private int _delayBetweenShots = 2000;

        public int DelayBetweenShots => _delayBetweenShots;
        
        public abstract void Launch(Vector3 direction);
    }
}