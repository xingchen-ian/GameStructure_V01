using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    // use singleton to create an envent manager
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EventManager>();
                if (_instance == null)
                {
                    GameObject eventManagerObject = new GameObject("EventManager");
                    _instance = eventManagerObject.AddComponent<EventManager>();
                }
            }
            return _instance;
        }
    }

    // declare multiple event that you hope to have
    public event Action OnExampleEvent;
    public event Action OnEvent2;
    // add more events here...

    // invoke events
    public void TriggerExampleEvent()
    {
        OnExampleEvent?.Invoke();
    }

    public void TriggerEvent2()
    {
        OnEvent2?.Invoke();
    }
    
    // add more functions to invoke more events...
}