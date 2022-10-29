using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGroup : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    private Spawner[] _spawners;
    private int _currentSpawnerIndex;

    private Coroutine _spawnJob;

    private void Start()
    {
        _spawners = GetComponentsInChildren<Spawner>();
    }

    private void Update()
    {
        if (_spawnJob == null)
        {
            _spawnJob = StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        _spawners[_currentSpawnerIndex++].Spawn();
        yield return new WaitForSeconds(_spawnDelay);

        if (_currentSpawnerIndex >= _spawners.Length)
        {
            _currentSpawnerIndex = 0;
        }

        _spawnJob = null;
    }
}
