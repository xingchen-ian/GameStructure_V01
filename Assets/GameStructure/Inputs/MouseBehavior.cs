using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MouseBehavior : MonoBehaviour
{
    public UnityEvent onClick;
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public UnityEvent onUp;
    public UnityEvent onOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnMouseDown()
    {
        //Called when the user has pressed the mouse button while over the Collider.
        Debug.Log("Mouse is down");
        onClick?.Invoke();
    }

    private void OnMouseEnter()
    {
        //Called when the mouse enters the Collider.
        Debug.Log("Mouse is over GameObject.");
        onEnter?.Invoke();
    }

    private void OnMouseOver()
    {
        //Called every frame while the mouse is over the Collider. This function can be a coroutine.
        Debug.Log("Mouse is over GameObject.");
        onOver?.Invoke();
    }
    
    private void OnMouseExit()
    {
        //Called when the mouse is not any longer over the Collider.
        Debug.Log("Mouse is not over GameObject.");
        onExit?.Invoke();
    }
    
    private void OnMouseUp()
    {
        //Called when the user has released the mouse button.
        Debug.Log("Mouse is up");
        onUp?.Invoke();
    }
    
    
}
