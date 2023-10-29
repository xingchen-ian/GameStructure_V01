using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeColor1()
    {
        GetComponent<Renderer>().material.color = color1;
    }
    
    public void ChangeColor2()
    {
        GetComponent<Renderer>().material.color = color2;
    }
    
    public void ChangeColor3()
    {
        GetComponent<Renderer>().material.color = color3;
    }
    
    public void ChangeColor4()
    {
        GetComponent<Renderer>().material.color = color4;
    }
    
    public void ChangeColor5()
    {
        GetComponent<Renderer>().material.color = color5;
    }
}
