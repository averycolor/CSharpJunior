using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxVolume;

    [SerializeField] private AudioSource _audioSource;

    private Coroutine _increaseVolumeJob;
    private Coroutine _decreaseVolumeJob;
    private float _volume;

    public float NormalizedVolume => _volume / _maxVolume;

    public void Activate()
    {
        if (_decreaseVolumeJob != null)
        {
            StopCoroutine(_decreaseVolumeJob);
        }

        _audioSource.Play();
        _increaseVolumeJob = StartCoroutine(ChangeVolume(1f));
    }

    public void Deactivate()
    {
        if (_increaseVolumeJob != null)
        {
            StopCoroutine(_increaseVolumeJob);
        }

        _decreaseVolumeJob = StartCoroutine(ChangeVolume(0f));
    }

    private void Update()
    {
        _audioSource.volume = _volume;
    }

    private IEnumerator ChangeVolume(float normalizedTarget)
    {
        while (NormalizedVolume != normalizedTarget)
        {
            _volume = Mathf.MoveTowards(_volume, _maxVolume * normalizedTarget, _sensitivity * Time.deltaTime);
            yield return null;
        }
    }
}