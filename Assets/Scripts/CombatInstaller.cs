using System.Collections;
using Components;
using Enemies.Presenter;
using Player.Health.Presenter;
using Player.Health.View;
using UnityEngine;

public class CombatInstaller : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _player;
    [Header("Views")]
    [SerializeField] private HealthView _healthView;
    [Header("Parameters")]
    [SerializeField] private float _enemiesSpawnTimeSpan;

    private HealthPresenter _health;

    private Coroutine _enemiesSpawnRoutine;

    private void Start()
    {
        _health = new(_healthView);

        StartEnemySpawn();
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