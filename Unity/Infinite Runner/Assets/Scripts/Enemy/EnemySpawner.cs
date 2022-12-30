using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Vector3[] _points;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeInterval;

    private void Start()
    {
        Initialize(_enemyPrefab);
        StartCoroutine(Spawn());    
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_timeInterval);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 point = _points[Random.Range(0, _points.Length)];
        
        if (TryGetObject(out GameObject result))
        {
            result.SetActive(true);
            result.transform.localPosition = point;
        }
    }
}
