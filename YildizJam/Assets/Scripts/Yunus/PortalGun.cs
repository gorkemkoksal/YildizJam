using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private GameObject portalRed;
    [SerializeField] private GameObject portalBlue;
    [SerializeField] private GameObject normalPortalBullet;

    public static string portalHolder;
    AudioSource portalSoundEffect;
    public AudioClip prt;
    public AudioClip shotgun;





    [SerializeField] private float bulletVelocity = 3f;
    private Transform mouseTransform;
    void Start()
    {
        mouseTransform = this.transform;
        bulletVelocity = 20f;
        portalSoundEffect = GetComponent<AudioSource>();


    }


    void Update()
    {
        LookAtMouse();
        BulletShoot();
        PortalSelect();
        if (Input.GetMouseButtonDown(1))
        {
            PortalShoot();
        }
    }

    private void LookAtMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition - mouseTransform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        mouseTransform.rotation = rotation;


    }
    private void BulletShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            portalSoundEffect.clip = shotgun;
            portalSoundEffect.Play();


            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            GameObject bullet = (GameObject)Instantiate(normalPortalBullet, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

        }
    }

    private void PortalSelect()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            portalHolder = "blue";

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            portalHolder = "red";
        }

    }

    private void PortalShoot()
    {
        

        if (portalHolder == "blue")
        {
            portalSoundEffect.clip = prt;
            portalSoundEffect.Play();
            Destroy(GameObject.FindGameObjectWithTag("BluePortal"));
            Destroy(GameObject.FindGameObjectWithTag("BluePortalBullet"));
            


            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            GameObject portalBlueReal = (GameObject)Instantiate(portalBlue, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);

            portalBlueReal.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;






        }

        if (portalHolder == "red")
        {
            portalSoundEffect.clip = prt;
            portalSoundEffect.Play();
            Destroy(GameObject.FindGameObjectWithTag("RedPortal"));
            Destroy(GameObject.FindGameObjectWithTag("RedPortalBullet"));


            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            GameObject portalRedReal = (GameObject)Instantiate(portalRed, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);

            portalRedReal.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;






        }



    }
}
