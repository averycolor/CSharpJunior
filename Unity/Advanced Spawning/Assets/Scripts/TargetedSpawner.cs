using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyTarget _target;
    [SerializeField] private float _spawnInterval;

    private Coroutine _spawnJob;

    private void Update()
    {
        if (_spawnJob == null)
        {
            _spawnJob = StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_spawnInterval);

        Enemy enemy = Instantiate(_enemy, transform);
        enemy.SetTarget(_target);

        _spawnJob = null;
    }
}
