using Core.Combat.Enemies.Presenter;
using Core.Combat.Enemies.View;
using UnityEngine;

namespace Core.Combat.Components
{
    public class BossSpawner : EnemySpawner
    {
        public new void StartEnemySpawn()
        {
            Spawn();
        }
        
        protected new BossPresenter Spawn()
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            EnemyView enemyView = Instantiate(_enemyPrefab, spawnPoint);
            
            BossPresenter enemy = new(enemyView, _player, _settings);

            enemy.Destroyed += Remove;
            
            _enemies.Add(enemy);

            return enemy;
        }
    }
}