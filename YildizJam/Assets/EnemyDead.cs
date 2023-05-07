using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
   
    void Start()
    {
        
    }

   private void OnCollisionEnter2D(Collision2D other)
   {
    if(other.gameObject.tag == "Bullet")
    {
        Destroy(gameObject);
    }
   }
}
