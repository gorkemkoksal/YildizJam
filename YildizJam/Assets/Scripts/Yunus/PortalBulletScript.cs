using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBulletScript : MonoBehaviour
{
    [SerializeField] private GameObject redPortalFirst;
    [SerializeField] private GameObject bluePortalFirst;
    public static Vector3 redPortalPosition;
    public static Vector3 bluePortalPosition;





    private void OnCollisionEnter2D(Collision2D other)
    {


        if (PortalGun.portalHolder == "red")

            Instantiate(redPortalFirst, transform.position, Quaternion.identity);
            Destroy(gameObject);

        if (PortalGun.portalHolder == "blue")
        {
            Instantiate(bluePortalFirst, transform.position, Quaternion.identity);
            Destroy(gameObject);




        }
    }
}
