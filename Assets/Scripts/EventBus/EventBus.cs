using System;
using System.Collections;

namespace EventBus
{
    public class EventBus
    {
        private Hashtable _events = new();

        public void AddListener(Events name, Action callback)
        {
            Action currentEvent = null;
            string key = name.ToString();
            
            if (_events.ContainsKey(key))
            {
                currentEvent = (Action)_events[key];
                currentEvent += callback;
                _events[key] = currentEvent;
            }
            else
            {
                currentEvent += callback;
                _events.Add(key, currentEvent);
            }
        }

        public void AddListener<T>(Events name, Action<T> callback)
        {
            string key = GetKey<T>(name);

            Action<T> currentEvent = null;

            if (_events.ContainsKey(key))
            {
                currentEvent = (Action<T>)_events[key];
                currentEvent += callback;
                _events[key] = currentEvent;
            }
            else
            {
                currentEvent += callback;
                _events.Add(key, currentEvent);
            }
        }

        public void RemoveListener<T>(Events name, Action<T> callback)
        {
            Action<T> currentEvent = null;
            string key = GetKey<T>(name);

            if (_events.ContainsKey(key))
            {
                currentEvent = (Action<T>)_events[key];
                currentEvent -= callback;
                _events[key] = currentEvent;
            }
        }

        public void RemoveListener(Events name, Action callback)
        {
            Action currentEvent = null;
            string key = name.ToString();

            if (_events.ContainsKey(key))
            {
                currentEvent = (Action)_events[key];
                currentEvent -= callback;
                _events[key] = currentEvent;
            }
        }

        public void TriggerEvent<T>(Events name, T returnedType)
        {
            Action<T> currentEvent;
            string key = GetKey<T>(name);

            if (_events.ContainsKey(key))
            {
                currentEvent = (Action<T>)_events[key];
                currentEvent.Invoke(returnedType);
            }
        }

        public void TriggerEvent(Events name)
        {
            Action currentEvent;
            string key = name.ToString();

            if (_events.ContainsKey(key))
            {
                currentEvent = (Action)_events[key];
                currentEvent.Invoke();
            }
        }

        private string GetKey<T>(Events eventName)
        {
            Type type = typeof(T);
            string key = type + eventName.ToString();
            return key;
        }
    }
}