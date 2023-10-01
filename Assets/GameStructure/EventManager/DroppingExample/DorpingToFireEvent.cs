using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorpingToFireEvent : MonoBehaviour
{
    private bool onGround;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // get the event manager;
        EventManager eventManager = EventManager.Instance;
        
        // fire the OnExampleEvent;
        eventManager.TriggerExampleEvent();

        onGround = true;
    }

    private void OnCollisionExit(Collision other)
    {
        onGround = false;
    }
}
