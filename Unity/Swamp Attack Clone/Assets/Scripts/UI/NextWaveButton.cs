using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private string _nextWaveFormat;
    [SerializeField] private string _inactiveFormat;

    private Button _button;
    private bool _isWaitingForWave;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (_isWaitingForWave)
        {
            _buttonText.text = string.Format(_nextWaveFormat, Mathf.Round(_spawner.NextWaveTimer));
        }
    }

    private void OnEnable()
    {
        _spawner.CurrentWaveComplete += OnCurrentWaveComplete;
        _spawner.WaveStart += OnWaveStart;
    }

    private void OnDisable()
    {
        _spawner.CurrentWaveComplete -= OnCurrentWaveComplete;
        _spawner.WaveStart -= OnWaveStart;
    }

    private void Hide()
    {
        _button.interactable = false;
        _button.image.enabled = false;
        _buttonText.enabled = false;
    }

    private void Show()
    {
        _button.interactable = true;
        _button.image.enabled = true;
        _buttonText.enabled = true;
    }

    private void OnWaveStart()
    {
        Hide();
        _isWaitingForWave = false;
        _buttonText.text = string.Format(_inactiveFormat);
    }

    private void OnCurrentWaveComplete()
    {
        if (_spawner.IsComplete == false)
        {
            Show();
            _isWaitingForWave = true;
            _buttonText.text = string.Format(_nextWaveFormat, _spawner.NextWaveTimer);
        }
    }
}
