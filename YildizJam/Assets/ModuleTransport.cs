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
        if(Input.GetKeyDown(KeyCode.E)){
            Transport();
            OnModule?.Invoke();
            Destroy(GameObject.Find("Module(Clone)"));
        }      
    }
    void Transport(){
        transform.position = GameObject.Find("Module(Clone)").transform.position;
    }
}
