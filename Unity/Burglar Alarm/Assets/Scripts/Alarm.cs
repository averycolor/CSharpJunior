using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxVolume;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _changeVolumeJob;
    private float _volume;

    public float NormalizedVolume => _volume / _maxVolume;

    public void SetEnabled(bool isEnabled)
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        float targetVolume = isEnabled ? 1f : 0f;
        _changeVolumeJob = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float normalizedTarget)
    {
        if (normalizedTarget > 0f)
        {
            _audioSource.Play();
        }

        while (NormalizedVolume != normalizedTarget)
        {
            _volume = Mathf.MoveTowards(_volume, _maxVolume * normalizedTarget, _sensitivity * Time.deltaTime);
            _audioSource.volume = _volume;
            yield return null;
        }

        if (normalizedTarget == 0f)
        {
            _audioSource.Stop();
        }
    }
}