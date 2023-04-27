using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public void SubscribeToEnemyDeath(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Entity deadEntity)
    {
        AddScore((deadEntity as Enemy).Reward);
    }

    private void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(score);
    }
}
