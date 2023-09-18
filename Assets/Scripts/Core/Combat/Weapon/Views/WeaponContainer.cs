using System;
using System.Linq;
using UnityEngine;

namespace Combat.Weapon.Views
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private PlacePointWeaponDictionary _arms;
        private float _baseDamageIncreaseRate = 1;
        private int _weaponOverrideIndex = 0;

        private int _enemiesInRange;

        public void Deploy(global::Combat.Weapon.Arms.Base.Arms newArms)
        {
            foreach ((Transform place, global::Combat.Weapon.Arms.Base.Arms _) in _arms)
            {
                if (_arms.ElementAt(_arms.Count - 1).Value != null)
                {
                    if (_weaponOverrideIndex == _arms.Count) _weaponOverrideIndex = 0;
                    
                    Transform newPoint = _arms.ElementAt(_weaponOverrideIndex).Key;
                    Destroy(_arms[newPoint].gameObject);
                    _arms[newPoint] = Instantiate(newArms, newPoint);
                    _arms[newPoint].SetDamageIncrease(_baseDamageIncreaseRate);
                    _weaponOverrideIndex++;
                    return;
                }
                
                if (_arms[place] != null) continue;

                _arms[place] = Instantiate(newArms, place);
                _arms[place].SetDamageIncrease(_baseDamageIncreaseRate);

                return;
            }
        }

        public void IncreaseBaseDamage(float amount)
        {
            _baseDamageIncreaseRate += amount / 100;

            foreach ((Transform _, Arms.Base.Arms arms) in _arms)
            {
                if (arms == null) continue;

                arms.SetDamageIncrease(_baseDamageIncreaseRate);
            }
        }

        public void ApplyUpgrade(object buff)
        {
            if (buff is Arms.Base.Arms newArms)
            {
                Deploy(newArms);
            }
        }
    }
    
    [Serializable]
    public class PlacePointWeaponDictionary : SerializableDictionary<Transform, Arms.Base.Arms> {}
}