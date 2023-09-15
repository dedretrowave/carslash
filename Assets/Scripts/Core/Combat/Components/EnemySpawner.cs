using System;
using System.Collections;
using System.Collections.Generic;
using Core.Combat.Enemies.Components;
using Core.Combat.Enemies.Presenter;
using Core.Combat.Enemies.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Combat.Components
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private Transform _player;
        [SerializeField] private float _spawnTimeSpan = 5;
        [SerializeField] private EnemySettings _settings;

        private List<EnemyPresenter> _enemies = new();
        private bool _canSpawn;

        public int LevelToBeginSpawn => _settings.LevelToBeginSpawn;

        public event Action<EnemyPresenter> EnemySpawned;

        public void ReduceTimeSpan(float amount)
        {
            _spawnTimeSpan -= amount;
        }

        public void StartEnemySpawn()
        {
            if (!_canSpawn) _canSpawn = true;
        
            StartCoroutine(SpawnContinuously());
        }
        
        public void StopEnemySpawn()
        {
            if (_canSpawn) _canSpawn = false;
        }

        private IEnumerator SpawnContinuously()
        {
            if (!_canSpawn) yield break;
        
            EnemyPresenter enemy = Spawn();
            
            EnemySpawned?.Invoke(enemy);

            yield return new WaitForSeconds(_spawnTimeSpan);

            yield return SpawnContinuously();
        }

        private EnemyPresenter Spawn()
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            EnemyView enemyView = Instantiate(_enemyPrefab, spawnPoint);

            EnemyPresenter enemy = new(enemyView, _player, _settings);

            enemy.Destroyed += Remove;
            
            _enemies.Add(enemy);

            return enemy;
        }

        public void Clear()
        {
            foreach (EnemyPresenter enemy in _enemies)
            {
                enemy.Destroyed -= Remove;
                enemy.CleanDestroy();
            }
            
            _enemies.Clear();
        }

        private void Remove(EnemyPresenter enemy)
        {
            enemy.Destroyed -= Remove;
            _enemies.Remove(enemy);
        }
    }
}