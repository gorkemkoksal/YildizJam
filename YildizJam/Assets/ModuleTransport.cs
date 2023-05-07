using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModuleTransport : MonoBehaviour
{
    public event Action OnModule;
    void Start()
    {       
    } 
    void Update()
    {
        if(GameObject.Find("Module(Clone)") != null)
        {
        if(Input.GetKeyDown(KeyCode.E)){
            Transport();
            OnModule?.Invoke();
            Destroy(GameObject.Find("Module(Clone)"));
        }
        }      
    }
    void Transport()
    {
        if(GameObject.Find("Module(Clone)") != null)
        {
        transform.position = GameObject.Find("Module(Clone)").transform.position;
        }
    }
}
