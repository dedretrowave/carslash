using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Player.InvincibilityFrame
{
    [Serializable]
    public class InvincibilityFrameSettings
    {
        [SerializeField] private float _durationInSecs = 3f;

        public float DurationInSecs => _durationInSecs;
    }
}