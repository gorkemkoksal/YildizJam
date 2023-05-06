using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject , 5f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
