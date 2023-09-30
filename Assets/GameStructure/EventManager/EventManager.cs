using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    // use singleton to create an envent manager
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();
                if (instance == null)
                {
                    GameObject eventManagerObject = new GameObject("EventManager");
                    instance = eventManagerObject.AddComponent<EventManager>();
                }
            }
            return instance;
        }
    }

    // declare multiple event that you hope to have
    public event Action OnExampleEvent;
    public event Action OnEvent2;
    // 添加更多事件...

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