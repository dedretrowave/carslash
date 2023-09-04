using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Weapon.Views
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private PlacePointWeaponDictionary _arms;

        private int _enemiesInRange;

        public void Deploy(Arms.Base.Arms newArms)
        {
            foreach ((Transform place, Arms.Base.Arms _) in _arms)
            {
                if (_arms.ElementAt(_arms.Count - 1).Value != null)
                {
                    Transform firstPoint = _arms.ElementAt(0).Key;
                    Destroy(_arms[firstPoint].gameObject);
                    Instantiate(newArms, firstPoint);
                    return;
                }
                
                if (_arms[place] != null) continue;

                Instantiate(newArms, place);
                return;
            }
        }
    }
    
    [Serializable]
    public class PlacePointWeaponDictionary : SerializableDictionary<Transform, Arms.Base.Arms> {}
}