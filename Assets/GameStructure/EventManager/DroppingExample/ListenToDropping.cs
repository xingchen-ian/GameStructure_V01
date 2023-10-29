using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenToDropping : MonoBehaviour
{
    private float forceValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        // get the EventManager
        EventManager eventManager = EventManager.Instance;
        
        // subscribe the private Jump function
        eventManager.OnExampleEvent += Jump;
        eventManager.OnExampleEvent += Log;
    }
    
    void Jump()
    {
        forceValue = Random.Range(100f, 300f);
        GetComponent<Rigidbody>().AddForce(Vector3.up * forceValue);
    }
    
    void Log()
    {
        Debug.Log("I am listening to the event");
    }
}
