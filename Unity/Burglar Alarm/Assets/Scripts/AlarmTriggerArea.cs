using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTriggerArea : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _alarm.Activate();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _alarm.Deactivate();
        }
    }
}
