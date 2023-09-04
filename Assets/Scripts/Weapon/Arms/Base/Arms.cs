using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon.Arms.Base
{
    public abstract class Arms : MonoBehaviour
    {
        [SerializeField] protected int delayBetweenShotsInSecs = 2;
    }
}