using System;
using UnityEngine;

namespace Player.Skin
{
    [Serializable]
    public class SkinSettings
    {
        [SerializeField] private Components.Skin _defaultSkin;

        public Components.Skin DefaultSkin => _defaultSkin;
    }
}