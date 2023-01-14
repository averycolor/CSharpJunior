using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _scoringDelay;

    private int _health;
    private int _score;
    private float _currentScoringDelay;

    public int MaxHealth => _maxHealth;
    public int Score => _score;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        _health = _maxHealth;
        _currentScoringDelay = _scoringDelay;
        HealthChanged?.Invoke(_health);
        ScoreChanged?.Invoke(_score);
    }

    private void Update()
    {
        AddScore();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Died.Invoke();
        }

        HealthChanged?.Invoke(_health);
    }

    public void AddScore()
    {
        _currentScoringDelay -= Time.deltaTime;

        if (_currentScoringDelay <= 0)
        {
            _currentScoringDelay = _scoringDelay;
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
