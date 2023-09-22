using Core.Combat.Enemies.Presenter;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Components
{
    public class BossSpawner : EnemySpawner
    {
        public override void StartEnemySpawn()
        {
            Spawn();
        }
        
        protected override void Spawn()
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            EnemyView enemyView = Instantiate(_enemyPrefab, spawnPoint);
            
            BossPresenter enemy = new(enemyView, _player, _settings);

            OnEnemySpawned(enemy);
        }
    }
}