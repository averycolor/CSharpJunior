using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxVolume;
    [SerializeField] private MeshRenderer _lightRenderer;
    [SerializeField] private Color _lightColor;

    private AudioSource _audioSource;
    private float _volume;
    private float _normalizedVolume => _volume / _maxVolume;

    private bool _intruderDetected;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateVolume();
        UpdateLightColor();
    }

    public void UpdateVolume()
    {
        if (_intruderDetected)
        {
            if (_volume < _maxVolume)
            {
                _volume = Mathf.MoveTowards(_volume, _maxVolume, _sensitivity * Time.deltaTime);
                _audioSource.volume = _volume;
            }
        }
        else
        {
            if (_volume > 0)
            {
                _volume = Mathf.MoveTowards(_volume, 0f, _sensitivity * Time.deltaTime);
                _audioSource.volume = _volume;
            }
            else {
                _audioSource.Stop();
            }
        }
    }

    public void UpdateLightColor()
    {
        _lightRenderer.material.SetColor("_EmissionColor", Color.Lerp(Color.black, _lightColor, _normalizedVolume));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.TryGetComponent(out Burglar burglar))
        {
            _intruderDetected = true;
        }

        _audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.TryGetComponent(out Burglar burglar))
        {
            _intruderDetected = false;
        }
    }
}