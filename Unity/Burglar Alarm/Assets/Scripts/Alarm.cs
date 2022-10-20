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

    private Coroutine _increaseVolumeJob;
    private Coroutine _decreaseVolumeJob;
    private AudioSource _audioSource;
    private float _volume;
    private float NormalizedVolume => _volume / _maxVolume;

    public void Activate()
    {
        if (_decreaseVolumeJob != null)
        {
            StopCoroutine(_decreaseVolumeJob);
        }

        _audioSource.Play();
        _increaseVolumeJob = StartCoroutine(IncreaseVolume());
    }

    public void Deactivate()
    {
        if (_increaseVolumeJob != null)
        {
            StopCoroutine(_increaseVolumeJob);
        }

        _decreaseVolumeJob = StartCoroutine(DecreaseVolume());
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.volume = _volume;
    }

    private void UpdateLightColor()
    {
        _lightRenderer.material.SetColor("_EmissionColor", Color.Lerp(Color.black, _lightColor, NormalizedVolume));
    }

    private IEnumerator IncreaseVolume()
    {
        while (NormalizedVolume < 1)
        {
            _volume = Mathf.MoveTowards(_volume, _maxVolume, _sensitivity * Time.deltaTime);
            UpdateLightColor();
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (NormalizedVolume > 0)
        {
            _volume = Mathf.MoveTowards(_volume, 0f, _sensitivity * Time.deltaTime * -1f);
            UpdateLightColor();

            if (NormalizedVolume == 0) 
            {
                _audioSource.Stop();
            }

            yield return null;
        }
    }
}