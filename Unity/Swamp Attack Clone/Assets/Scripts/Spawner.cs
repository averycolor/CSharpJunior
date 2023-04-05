using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _firstWaveIndex;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private float _timeToNextSpawn;

    public int CurrentWaveIndex { get; private set; }
    public float NextWaveTimer { get; private set; }
    public bool IsComplete => _waves.All(wave => wave.IsComplete);
    public float CurrentWaveProgress => _currentWave.Progress;

    public event UnityAction CurrentWaveComplete;
    public event UnityAction WaveStart;

    private void Start()
    {
        foreach (Wave wave in _waves)
        {
            wave.InitParts();
        }

        TrySetWave(_firstWaveIndex);
    }

    private void Update()
    {
        if (NextWaveTimer > 0f)
        {
            NextWaveTimer -= Time.deltaTime;
            return;
        }
        else if (_currentWave.IsComplete)
        {
            if (TrySetNextWave() == false)
            {
                Destroy(gameObject);
            }
        }

        _timeToNextSpawn -= Time.deltaTime;

        if (_timeToNextSpawn <= 0f)
        {
            _timeToNextSpawn = _currentWave.SpawnInterval;
            SpawnEnemy();

            if (_currentWave.IsComplete)
            {
                CurrentWaveComplete?.Invoke();
                NextWaveTimer = _currentWave.TimeToNextWave;
            }
        }
    }

    public void OnNextWaveButtonClick()
    {
        TrySetNextWave();
    }

    private bool TrySetNextWave()
    {
        return TrySetWave(CurrentWaveIndex + 1);
    }

    private void SpawnEnemy()
    {
        var randomWavePart = _currentWave.GetRandomPart();

        if (randomWavePart == null)
        {
            return;
        }

        Enemy newEnemy = Instantiate(randomWavePart.Template, transform.position, Quaternion.identity);
        newEnemy.transform.Translate(newEnemy.SpawnOffset);
        newEnemy.Init(_target);
        randomWavePart.DecreaseCount();
    }

    private bool TrySetWave(int index)
    {
        if (index < _waves.Count)
        {
            NextWaveTimer = 0f;
            CurrentWaveIndex = index % _waves.Count;
            _currentWave = _waves[CurrentWaveIndex];
            _timeToNextSpawn = 0f;
            WaveStart?.Invoke();
            return true;
        }

        return false;
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private List<WavePart> _parts;
    [field: SerializeField] public float SpawnInterval { get; private set; }

    [field: SerializeField] public float TimeToNextWave { get; private set; }
    public bool IsComplete => _parts.All(part => part.IsComplete);
    public float Progress { get
        {
            float progressSum = 0;

            foreach (WavePart part in _parts)
            {
                progressSum += part.Progress;
            }

            return progressSum / _parts.Count;
        } }

    public WavePart GetRandomPart()
    {
        List<WavePart> eligibleParts = _parts.Where(part => part.IsComplete == false).ToList();

        if (eligibleParts.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, eligibleParts.Count - 1);

        return eligibleParts[index];
    }

    public void InitParts()
    {
        foreach (WavePart part in _parts)
        {
            part.Init();
        }
    }
}

[System.Serializable]
public class WavePart
{
    [field: SerializeField] public Enemy Template { get; private set; }
    [SerializeField] private int _startingCount;

    private int _count;

    public bool IsComplete => _count <= 0;
    public float Progress { get; private set; }

    public void Init()
    {
        _count = _startingCount;
    }

    public void DecreaseCount()
    {
        if (_count <= 0)
        {
            return;
        }

        _count--;
        Progress += 1f / _startingCount;
    }
}