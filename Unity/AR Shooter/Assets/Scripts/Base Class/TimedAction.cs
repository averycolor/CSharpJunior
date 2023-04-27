using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TimedAction : MonoBehaviour
{
    [SerializeField] private float _minInterval;
    [SerializeField] private float _maxInterval;
    [SerializeField] private bool _isRepeated;

    private Coroutine _keepTimeJob;

    private event UnityAction Timer;

    private void OnEnable()
    {
        Timer += OnTimer;
    }

    private void OnDisable()
    {
        Timer -= OnTimer;
    }

    private void Start()
    {
        TryStartJob();
    }

    protected void Repeat(bool state)
    {
        _isRepeated = state;

        if (_isRepeated)
        {
            TryStartJob();
        }
    }

    protected virtual void OnTimer() { }

    private IEnumerator KeepTime()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(_minInterval, _maxInterval));
            Timer?.Invoke();
        } while (_isRepeated);

        _keepTimeJob = null;
    }

    private bool TryStartJob()
    {
        if (_keepTimeJob == null)
        {
            _keepTimeJob = StartCoroutine(KeepTime());
            return true;
        }

        return false;
    }
}
