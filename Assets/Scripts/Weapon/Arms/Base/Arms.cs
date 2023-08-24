using UnityEngine;

namespace Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        public abstract void Launch(Vector3 direction);
    }
}