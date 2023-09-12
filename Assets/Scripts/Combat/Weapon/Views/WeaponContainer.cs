using System;
using System.Linq;
using LevelProgression.Upgrades.Events;
using UnityEngine;

namespace Combat.Weapon.Views
{
    public class WeaponContainer : MonoBehaviour
    {
        [SerializeField] private PlacePointWeaponDictionary _arms;
        private float _baseDamageIncrease = 1;

        private int _enemiesInRange;

        public void Deploy(global::Combat.Weapon.Arms.Base.Arms newArms)
        {
            foreach ((Transform place, global::Combat.Weapon.Arms.Base.Arms _) in _arms)
            {
                if (_arms.ElementAt(_arms.Count - 1).Value != null)
                {
                    Transform firstPoint = _arms.ElementAt(0).Key;
                    Destroy(_arms[firstPoint].gameObject);
                    _arms[firstPoint] = Instantiate(newArms, firstPoint);
                    _arms[firstPoint].SetDamageIncrease(_baseDamageIncrease);
                    return;
                }
                
                if (_arms[place] != null) continue;

                _arms[place] = Instantiate(newArms, place);
                _arms[place].SetDamageIncrease(_baseDamageIncrease);

                return;
            }
        }

        public void IncreaseBaseDamage(float amount)
        {
            _baseDamageIncrease += amount / 100;

            foreach ((Transform _, Arms.Base.Arms arms) in _arms)
            {
                if (arms == null) continue;

                arms.SetDamageIncrease(_baseDamageIncrease);
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