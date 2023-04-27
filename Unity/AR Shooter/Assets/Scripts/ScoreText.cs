using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _text;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged; 
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        if (_text == null)
        {
            _text = GetComponent<TMP_Text>();
        }

        _text.text = newScore.ToString();
    }
}
