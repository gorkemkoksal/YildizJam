using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject stopMenu;
   
    void Start()
    {
        stopMenu.SetActive(false);
    }
    

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            stopMenu.SetActive(true);


        }
        
    }
}
