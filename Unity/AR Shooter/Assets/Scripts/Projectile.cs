using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _startingVelocity;
    [SerializeField] private float _scaleChangeSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    private Rigidbody _rigidbody;
    private bool _scaledUp;
    private Coroutine _scaleUpJob;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _scaleUpJob = StartCoroutine(ChangeScale(Vector3.zero, transform.localScale));
    }

    private IEnumerator ChangeScale(Vector3 startingScale, Vector3 targetScale, bool dieAfterScale = false)
    {
        transform.localScale = startingScale;

        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, Time.deltaTime * _scaleChangeSpeed);
            yield return null;
        }

        if (startingScale.magnitude < targetScale.magnitude)
        {
            _scaledUp = true;
        }

        if (dieAfterScale)
        {
            Destroy(gameObject);
        }
    }

    public bool TryRelease()
    {
        if (_scaledUp)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.up * _startingVelocity, ForceMode.VelocityChange);
            StartCoroutine(DelayLifeTime());
            return true;
        }

        StopCoroutine(_scaleUpJob);
        StartCoroutine(ChangeScale(transform.localScale, Vector3.zero, true));
        return false;
    }

    private IEnumerator DelayLifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
