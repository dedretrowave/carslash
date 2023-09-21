using System;
using UnityEngine;

namespace Player.Skin
{
    [Serializable]
    public class SkinSettings
    {
        [SerializeField] private Core.Player.Skin.Components.Skin _defaultSkin;

        public Core.Player.Skin.Components.Skin DefaultSkin => _defaultSkin;
    }
}