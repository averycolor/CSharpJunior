using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Coroutine _moveToWorldOriginJob;

    private void Start()
    {
        _moveToWorldOriginJob = StartCoroutine(MoveToWorldOrigin());
    }

    private void Update()
    {
        if (_moveToWorldOriginJob == null)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator MoveToWorldOrigin()
    {
        while (transform.position != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _movementSpeed * Time.deltaTime);
            yield return null;
        }

        _moveToWorldOriginJob = null;
    }
}
