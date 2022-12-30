using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _text.text = health.ToString();
    }
}
