using System;
using System.Collections;
using System.Collections.Generic;
using Combat.Weapon.Arms.Base;
using Combat.Weapon.Views;
using Core.Combat.Components;
using Core.Combat.Enemies.Presenter;
using DI;
using LevelProgression.Upgrades.Events;
using Player.Health.Presenter;
using Player.Health.View;
using UnityEngine;
using UnityEngine.Serialization;
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
        [SerializeField] private WeaponContainer _weapon;

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

        private void OnEnemySpawned(EnemyPresenter enemy)
        {
            enemy.Collide += OnEnemyAttack;
            enemy.Destroyed += UnsubscribeFromEnemy;
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
            StartEnemySpawn(levelIndex);
        }

        private void OnEnemyAttack(Transform collision, EnemyPresenter enemy)
        {
            if (collision.Equals(_player))
            {
                UnsubscribeFromEnemy(enemy);
                enemy.Destroy();
                _health.Reduce();
            }
        }
        
        public void ClearEnemies()
        {
            _enemySpawners.ForEach(spawner => spawner.StopEnemySpawn());
            _enemySpawners.ForEach(spawner => spawner.Clear());
        }
        
        private void StartEnemySpawn(int levelIndex)
        {
            _enemySpawners.ForEach(spawner =>
            {
                if (spawner.LevelToBeginSpawn <= levelIndex)
                {
                    spawner.StartEnemySpawn();
                }
            });
        }
    
        private void UnsubscribeFromEnemy(EnemyPresenter enemy)
        {
            enemy.Collide -= OnEnemyAttack;
            enemy.Destroyed -= UnsubscribeFromEnemy;
        }
    }
}