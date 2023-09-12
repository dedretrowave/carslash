using System;
using System.Collections;
using System.Collections.Generic;
using Combat.Components;
using Combat.Enemies.Presenter;
using Combat.Weapon.Arms.Base;
using Combat.Weapon.Views;
using DI;
using LevelProgression.Upgrades.Events;
using Player.Health.Presenter;
using Player.Health.View;
using UnityEngine;
using Upgrades.Components;

namespace Combat
{
    public class CombatInstaller : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Transform _player;
        [SerializeField] private List<Arms> _defaultArms;
        [Header("Views")]
        [SerializeField] private HealthView _healthView;
        [SerializeField] private WeaponContainer _weapon;
        [Header("Parameters")]
        [SerializeField] private float _enemiesSpawnTimeSpan = 5;

        private UpgradeResolver _upgradeResolver;

        private HealthPresenter _health;

        private bool _canSpawn;

        public event Action OutOfHealth;

        public void Construct()
        {
            _upgradeResolver = DependencyContext.Dependencies.Get<UpgradeResolver>();
            
            _health = new(_healthView);

            _weapon.Deploy(_defaultArms[0]);
            _weapon.Deploy(_defaultArms[1]);

            StartEnemySpawn();
            
            _upgradeResolver.Subscribe<float>(UpgradeType.HealthAmount, _health.Add);
            _upgradeResolver.Subscribe<float>(UpgradeType.HealthRegen, _health.Regen);
            _upgradeResolver.Subscribe<Arms>(UpgradeType.Weapon, _weapon.Deploy);
            _upgradeResolver.Subscribe<float>(UpgradeType.Damage, _weapon.IncreaseBaseDamage);

            _health.OutOfHealth += OnOutOfHealth;
        }

        public void Disable()
        {
            _health.OutOfHealth -= OnOutOfHealth;
            
            _upgradeResolver.Unsubscribe<float>(UpgradeType.HealthAmount, _health.Add);
            _upgradeResolver.Unsubscribe<float>(UpgradeType.HealthRegen, _health.Regen);
            _upgradeResolver.Unsubscribe<Arms>(UpgradeType.Weapon, _weapon.Deploy);
            _upgradeResolver.Unsubscribe<float>(UpgradeType.Damage, _weapon.IncreaseBaseDamage);
            
            _health.Disable();
        }

        private void OnOutOfHealth()
        {
            OutOfHealth?.Invoke();
            Disable();
        }

        public void OnNewLevelStarted(int levelIndex)
        {
            float enemySpawnTimeCut = levelIndex * .2f;
            _enemiesSpawnTimeSpan -= enemySpawnTimeCut;
            
            StartEnemySpawn();
        }

        public void ClearEnemies()
        {
            StopEnemySpawn();
            _enemySpawner.Clear();
        }

        private void StartEnemySpawn()
        {
            if (!_canSpawn) _canSpawn = true;
        
            StartCoroutine(SpawnEnemiesContinuously());
        }

        private void StopEnemySpawn()
        {
            if (_canSpawn) _canSpawn = false;
        }

        private IEnumerator SpawnEnemiesContinuously()
        {
            if (!_canSpawn) yield break;
        
            EnemyPresenter enemy = _enemySpawner.Spawn();
        
            enemy.Collide += OnEnemyAttack;
            enemy.Destroyed += UnsubscribeFromEnemy;

            yield return new WaitForSeconds(_enemiesSpawnTimeSpan);

            yield return SpawnEnemiesContinuously();
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
    
        private void UnsubscribeFromEnemy(EnemyPresenter enemy)
        {
            enemy.Collide -= OnEnemyAttack;
            enemy.Destroyed -= UnsubscribeFromEnemy;
        }

        public void ApplyUpgrade(object propertyIncreaseAmount)
        {
            
        }
    }
}