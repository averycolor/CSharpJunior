using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private string _format;

    private TMP_Text _text;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnDied()
    {
        _text.text = string.Format(_format, _player.Score.ToString());
    }
}
