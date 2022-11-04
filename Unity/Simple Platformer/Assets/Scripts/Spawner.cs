using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _template;

    private Coin _lastSpawned;

    public Coin Spawn()
    {
        Coin spawnResult = Instantiate(_template, transform);
        spawnResult.transform.localEulerAngles = Vector2.zero;
        spawnResult.transform.localRotation = Quaternion.identity;
        _lastSpawned = spawnResult;
        return spawnResult;
    }

    public bool HasSpawnedObject()
    {
        return _lastSpawned != null;
    }
}
