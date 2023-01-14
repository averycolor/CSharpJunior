using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _scoreText;

    private void OnEnable()
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TMP_Text>();
        }

        _player.ScoreChanged  += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}