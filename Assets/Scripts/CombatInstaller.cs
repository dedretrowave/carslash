using System;
using System.Collections;
using Components;
using Enemies.Presenter;
using Player.Health.Presenter;
using Player.Health.View;
using UnityEngine;
using Weapon.Arms;
using Weapon.Presenter;
using Weapon.Views;

public class CombatInstaller : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _player;
    [SerializeField] private Rocket _rocket;
    [Header("Views")]
    [SerializeField] private HealthView _healthView;
    [SerializeField] private WeaponView _weaponView;
    [Header("Parameters")]
    [SerializeField] private float _enemiesSpawnTimeSpan;

    private HealthPresenter _health;
    private WeaponPresenter _weapon;

    private Coroutine _enemiesSpawnRoutine;

    private void Start()
    {
        _health = new(_healthView);
        _weapon = new(_weaponView);
        
        _weapon.SetArms(_rocket);

        StartEnemySpawn();
    }

    private void OnDisable()
    {
        _weapon.Disable();
    }

    private void StartEnemySpawn()
    {
        StopEnemySpawn();
        _enemiesSpawnRoutine = StartCoroutine(SpawnEnemiesContinuously());
    }

    private void StopEnemySpawn()
    {
        if (_enemiesSpawnRoutine != null)
        {
            StopCoroutine(_enemiesSpawnRoutine);
        }
    }

    private IEnumerator SpawnEnemiesContinuously()
    {
        EnemyPresenter enemy = _enemySpawner.Spawn();
        
        enemy.OnCollide += OnEnemyAttack;

        yield return new WaitForSeconds(_enemiesSpawnTimeSpan);

        yield return SpawnEnemiesContinuously();
    }

    private void OnEnemyAttack(Transform collision, EnemyPresenter enemy)
    {
        enemy.OnCollide -= OnEnemyAttack;

        if (collision.Equals(_player))
        {
            enemy.Destroy();
            _health.Reduce();
        }
    }
}