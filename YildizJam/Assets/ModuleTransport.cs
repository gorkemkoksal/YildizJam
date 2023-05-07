using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTransport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Transport();
            Destroy(GameObject.Find("Module(Clone)"));
        }
        
    }
    void Transport(){
        transform.position = GameObject.Find("Module(Clone)").transform.position;
    }
}
