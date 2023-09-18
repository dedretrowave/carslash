using System;
using System.Collections.Generic;
using Core.Combat.Components;
using Core.Combat.Enemies.Presenter;
using Core.Combat.Weapon;
using Core.Combat.Weapon.Arms.Base;
using Core.Player.Health.View;
using DI;
using LevelProgression.Upgrades.Events;
using Player.Health.Presenter;
using UnityEngine;
using Upgrades.Components;

namespace Combat
{
    public class CombatInstaller : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private List<EnemySpawner> _enemySpawners;
        [SerializeField] private Transform _player;
        [SerializeField] private List<Arms> _defaultArms;
        [Header("Views")]
        [SerializeField] private HealthView _healthView;
        [SerializeField] private WeaponController _weapon;

        private UpgradesEventManager _upgradesEventManager;

        private HealthPresenter _health;

        public event Action OutOfHealth;

        public void Construct()
        {
            _upgradesEventManager = DependencyContext.Dependencies.Get<UpgradesEventManager>();
            
            _health = new(_healthView);

            _weapon.Deploy(_defaultArms[0]);
            _enemySpawners.ForEach(spawner => spawner.EnemySpawned += OnEnemySpawned);

            _upgradesEventManager.Subscribe<float>(UpgradeType.HealthAmount, _health.Add);
            _upgradesEventManager.Subscribe<float>(UpgradeType.HealthRegen, _health.Regen);
            _upgradesEventManager.Subscribe<Arms>(UpgradeType.Weapon, _weapon.Deploy);
            _upgradesEventManager.Subscribe<float>(UpgradeType.Damage, _weapon.IncreaseBaseDamage);

            _health.OutOfHealth += OnOutOfHealth;
            StartEnemySpawn(1);
        }

        public void Disable()
        {
            _enemySpawners.ForEach(spawner => spawner.EnemySpawned -= OnEnemySpawned);

            _upgradesEventManager.Unsubscribe<float>(UpgradeType.HealthAmount, _health.Add);
            _upgradesEventManager.Unsubscribe<float>(UpgradeType.HealthRegen, _health.Regen);
            _upgradesEventManager.Unsubscribe<Arms>(UpgradeType.Weapon, _weapon.Deploy);
            _upgradesEventManager.Unsubscribe<float>(UpgradeType.Damage, _weapon.IncreaseBaseDamage);
            
            _health.OutOfHealth -= OnOutOfHealth;
            _health.Disable();
        }
        
        private void StartEnemySpawn(int levelIndex)
        {
            _enemySpawners.ForEach(spawner =>
            {
                if (spawner.LevelToBeginSpawn > levelIndex) return;
                
                if (spawner.IsSpawnedInLevelIntervals)
                {
                    if (levelIndex % spawner.LevelToBeginSpawn == 0)
                    {
                        spawner.StartEnemySpawn();
                    }

                    return;
                }
                
                spawner.StartEnemySpawn();
            });
        }

        private void OnEnemySpawned(EnemyPresenter enemy)
        {
            
            enemy.Collide += OnEnemyAttack;
            enemy.Destroyed += UnsubscribeFromEnemy;
        }

        private void OnEnemyAttack(Transform collision, EnemyPresenter enemy)
        {
            if (!collision.Equals(_player)) return;

            UnsubscribeFromEnemy(enemy);
            enemy.OnAttack(_player);
            _health.Reduce();
        }

        private void UnsubscribeFromEnemy(EnemyPresenter enemy)
        {
            enemy.Collide -= OnEnemyAttack;
            enemy.Destroyed -= UnsubscribeFromEnemy;
        }
        
        private void OnOutOfHealth()
        {
            OutOfHealth?.Invoke();
            Disable();
        }

        public void OnNewLevelStarted(int levelIndex)
        {
            float enemySpawnTimeCut = .2f;
            _enemySpawners.ForEach(spawner => spawner.ReduceTimeSpan(enemySpawnTimeCut));
            _weapon.StartShooting();
            StartEnemySpawn(levelIndex);
        }

        public void OnLevelEnded()
        {
            ClearEnemies();
            _weapon.StopShooting();
        }

        public void ClearEnemies()
        {
            _enemySpawners.ForEach(spawner => spawner.StopEnemySpawn());
            _enemySpawners.ForEach(spawner => spawner.Clear());
        }
    }
}