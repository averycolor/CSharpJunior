using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _startingCount;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize()
    {
        for (int i = 0; i < _startingCount; i++)
        {
            GameObject newGameObject = Instantiate(_prefab, _container);
            newGameObject.SetActive(false);
            _pool.Add(newGameObject);
        }
    }

    private GameObject InitializeObject(GameObject prefab)
    {
        GameObject newGameObject = Instantiate(prefab, _container);
        newGameObject.SetActive(false);
        _pool.Add(newGameObject);
        return newGameObject;
    }

    protected GameObject GetObject()
    {
        GameObject result = _pool.FirstOrDefault(p => p.activeSelf == false);

        if (result == null)
        {
            result = InitializeObject(_prefab);
        }

        return result;
    }
}
