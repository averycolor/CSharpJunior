using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTriggerArea : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
