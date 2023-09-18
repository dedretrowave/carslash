using System;
using System.Collections;
using Core.Combat.Weapon.Arms.Base;
using LevelProgression.Upgrades.Upgrades;
using LevelProgression.Upgrades.Upgrades.Base;
using UnityEngine;
using Upgrades.Components;

namespace LevelProgression.Upgrades.Events
{
    public class UpgradesEventManager
    {
        private readonly Hashtable _listeners = new();

        public void Subscribe<T>(UpgradeType type, Action<T> applyCallback)
        {
            string key = GetKey<T>(type);

            Action<T> currentEvent = null;

            if (_listeners.ContainsKey(key))
            {
                currentEvent = (Action<T>)_listeners[key];
                currentEvent += applyCallback;
                _listeners[key] = currentEvent;
            }
            else
            {
                currentEvent += applyCallback;
                _listeners.Add(key, currentEvent);
            }
        }

        public void Unsubscribe<T>(UpgradeType type, Action<T> applyCallback)
        {
            Action<T> currentEvent = null;
            string key = GetKey<T>(type);

            if (_listeners.ContainsKey(key))
            {
                currentEvent = (Action<T>)_listeners[key];
                currentEvent -= applyCallback;
                _listeners[key] = currentEvent;
            }
        }
        
        public void Apply(Upgrade upgrade)
        {
            string key = upgrade.Type.ToString();

            switch (upgrade)
            {
                case WeaponUpgrade:
                    key += typeof(Arms);
                    
                    if (_listeners.ContainsKey(key))
                    {
                        Action<Arms> currentEvent = (Action<Arms>)_listeners[key];
                        currentEvent.Invoke((Arms) upgrade.Buff);
                    }
                    break;
                case PropertyUpgrade:
                    key += typeof(float);

                    if (_listeners.ContainsKey(key))
                    {
                        Action<float> currentEvent = (Action<float>)_listeners[key];
                        currentEvent.Invoke((float) upgrade.Buff);
                    }
                    break;
                default:
                    return;
            }
        }
        
        private string GetKey<T>(UpgradeType upgradeType)
        {
            Type type = typeof(T);
            string key = upgradeType.ToString() + type;
            return key;
        }
    }
}