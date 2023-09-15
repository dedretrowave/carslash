using System;
using UnityEngine;

namespace Core.Combat.Enemies.Components
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _levelToBeginSpawn;
        [SerializeField] private bool _isSpawnedOncePerLevel;

        public float MaxHealth => _maxHealth;
        public int LevelToBeginSpawn => _levelToBeginSpawn;
        public bool IsSpawnedOncePerLevel => _isSpawnedOncePerLevel;
    }
}