using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : TimedAction
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private float _radius;
    [SerializeField] private Player _enemyTarget;

    private Coroutine _spawnJob;

    public void StopSpawning()
    {
        Repeat(false);
    }

    protected override void OnTimer()
    {
        SpawnRandomEnemy();
    }

    private void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, _enemies.Count);
        Enemy enemy = _enemies[enemyIndex];
        Vector3 position = Random.insideUnitSphere * _radius;
        position.y = Mathf.Abs(position.y);

        Enemy newEnemy = Instantiate(enemy, position, Quaternion.identity);
        newEnemy.Init(_enemyTarget);
        _enemyTarget.SubscribeToEnemyDeath(newEnemy);
    }
}