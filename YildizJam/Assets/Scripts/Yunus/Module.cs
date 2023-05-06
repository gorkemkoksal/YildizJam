using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
   
    
    [SerializeField] private  GameObject moduleGun;
    
    void Update()
    {
        Destroy(gameObject , ModuleGun.moduleCoolDown - 0.5f);
        
       
        
    }
    
}
