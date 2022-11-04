using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGroup : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    private Spawner[] _spawners;
    private int _currentSpawnerIndex;

    private void Start()
    {
        _spawners = GetComponentsInChildren<Spawner>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Spawner currentSpawner = _spawners[_currentSpawnerIndex++];
        
        if (currentSpawner.HasSpawnedObject() == false)
        {
            currentSpawner.Spawn();
        }

        yield return new WaitForSeconds(_spawnDelay);

        if (_currentSpawnerIndex >= _spawners.Length)
        {
            _currentSpawnerIndex = 0;
        }

        StartCoroutine(Spawn());
    }
}
