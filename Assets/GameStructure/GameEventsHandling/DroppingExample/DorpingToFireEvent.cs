using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorpingToFireEvent : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // get the event manager;
        EventManager eventManager = EventManager.Instance;
        
        // fire the OnExampleEvent;
        eventManager.TriggerExampleEvent();
    }
}
