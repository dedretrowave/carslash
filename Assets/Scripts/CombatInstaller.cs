using System.Collections;
using Components;
using Enemies.Presenter;
using Player.Health.Presenter;
using Player.Health.View;
using UnityEngine;
using Weapon.Arms.Base;
using Weapon.Views;

public class CombatInstaller : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _player;
    [SerializeField] private Arms _defaultArms;
    [Header("Views")]
    [SerializeField] private HealthView _healthView;
    [SerializeField] private WeaponContainer _weapon;
    [Header("Parameters")]
    [SerializeField] private float _enemiesSpawnTimeSpan;

    private HealthPresenter _health;

    private Coroutine _enemiesSpawnRoutine;

    private void Start()
    {
        _health = new(_healthView);

        _weapon.Deploy(_defaultArms);

        StartEnemySpawn();
    }

    private void OnDisable()
    {
        
    }

    private void StartEnemySpawn()
    {
        StopEnemySpawn();
        _enemiesSpawnRoutine = StartCoroutine(SpawnEnemiesContinuously());
    }

    public void StopEnemySpawn()
    {
        if (_enemiesSpawnRoutine != null)
        {
            StopCoroutine(_enemiesSpawnRoutine);
        }
    }

    private IEnumerator SpawnEnemiesContinuously()
    {
        EnemyPresenter enemy = _enemySpawner.Spawn();
        
        enemy.Collide += OnEnemyAttack;

        yield return new WaitForSeconds(_enemiesSpawnTimeSpan);

        yield return SpawnEnemiesContinuously();
    }

    private void OnEnemyAttack(Transform collision, EnemyPresenter enemy)
    {
        if (collision.Equals(_player))
        {
            enemy.Collide -= OnEnemyAttack;
            enemy.Destroy();
            _health.Reduce();
        }
    }
}