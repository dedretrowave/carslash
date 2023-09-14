using DI;
using UnityEngine;

namespace Save
{
    public class SaveMediator : MonoBehaviour
    {
        private string _serializedData;
        
        public string SerializedData => _serializedData;

        private void Awake()
        {
            DependencyContext.Dependencies.Add(new(typeof(SaveMediator), () => this));
        }

        public void SetSerializedData(string data)
        {
            _serializedData = data;
        }
    }
}