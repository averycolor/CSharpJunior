using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyTarget _target;
    [SerializeField] private float _spawnInterval;

    private bool _isSpawning;

    private void Start()
    {
        StartCoroutine(Spawn());
        StartSpawning();
    }

    public void StopSpawning()
    {
        _isSpawning = false;
    }

    public void StartSpawning()
    {
        _isSpawning = true;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_isSpawning)
            {
                yield return new WaitForSeconds(_spawnInterval);

                Enemy enemy = Instantiate(_enemy, transform);
                enemy.SetTarget(_target);
            } 
            else
            {
                yield return null;
            }
        }
    }
}
