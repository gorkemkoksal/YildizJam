using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private GameObject redPortal;
    private GameObject bluePortal;

    private GameObject player;

    void Start()
    {
        redPortal = GameObject.FindGameObjectWithTag("RedPortal");
        bluePortal = GameObject.FindGameObjectWithTag("BluePortal");

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "RedPortal")
            {
                player.transform.position = bluePortal.transform.position;
            }
            if (this.gameObject.tag == "BluePortal")
            {
                player.transform.position = redPortal.transform.position;
            }

        }


    }


}
