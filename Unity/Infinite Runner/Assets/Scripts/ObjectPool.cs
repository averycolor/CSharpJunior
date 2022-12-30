using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject newGameObject = Instantiate(prefab, _container);
            newGameObject.SetActive(false);
            _pool.Add(newGameObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}
