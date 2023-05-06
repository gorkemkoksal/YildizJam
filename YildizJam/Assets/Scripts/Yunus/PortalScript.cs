using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private GameObject redPortal;
    [SerializeField] private GameObject bluePortal;
    [SerializeField] private GameObject player;

    private bool transformation = true;

    void Update()
    {
        if (transformation == false)
        {
            StartCoroutine(Teleport());

        }
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transformation == true)
        {
            if (other.gameObject.tag == "RedPortal")
            {
                player.transform.position = GameObject.Find("BluePortal(Clone)").transform.position;
                transformation = false;

            }
            if (other.gameObject.tag == "BluePortal")
            {
                player.transform.position = GameObject.Find("RedPortal(Clone)").transform.position;
                transformation = false;

            }


        }

        




    }
    IEnumerator Teleport()
        {
            transformation = false;
            yield return new WaitForSeconds(0.001f);
            transformation = true;
        }
}
