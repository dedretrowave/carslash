using System.Collections.Generic;
using Combat.Enemies.Presenter;
using Combat.Enemies.View;
using UnityEngine;

namespace Combat.Components
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private Transform _player;

        public EnemyPresenter Spawn()
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            EnemyView enemyView = Instantiate(_enemyPrefab, spawnPoint);

            EnemyPresenter enemy = new(enemyView, _player);

            return enemy;
        }
    }
}