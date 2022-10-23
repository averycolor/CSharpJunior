using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTriggerArea : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _alarm.SetEnabled(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _alarm.SetEnabled(false);
        }
    }
}
