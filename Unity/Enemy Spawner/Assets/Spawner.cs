using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    public Enemy Spawn()
    {
        Enemy spawnResult = Instantiate(_template, transform);
        spawnResult.transform.localEulerAngles = Vector3.zero;
        spawnResult.transform.localRotation = Quaternion.identity;
        return spawnResult;
    }
}
