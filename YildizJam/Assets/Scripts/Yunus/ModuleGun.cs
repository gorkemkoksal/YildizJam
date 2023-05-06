using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGun : MonoBehaviour
{
    [SerializeField] private GameObject module;
    [SerializeField] private GameObject normalBullet;
    public static  float moduleCoolDown;

    public static bool moduleShooting = true;
    

    [SerializeField] private float bulletVelocity = 20f;
    AudioSource moduleSoundEffect;
    public AudioClip M4Sound;
    public AudioClip ModuleSound;
    private Transform mouseTransform;
    void Start()
    {
        mouseTransform = this.transform;
        bulletVelocity = 20f;
        moduleCoolDown = 3f;
        moduleSoundEffect = GetComponent<AudioSource>();
    }
    
    void Update()
    {
       
       BulletShoot();
       StartCoroutine(ModuleShoot());    
    }

   

    private void BulletShoot()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 direction = (Vector2)((worldMousePos - transform.position));
         direction.Normalize();
        if(Input.GetMouseButtonDown(0))
        {
            moduleSoundEffect.clip = M4Sound;
            moduleSoundEffect.PlayOneShot(M4Sound);
         
         
         GameObject bullet = (GameObject)Instantiate(normalBullet, transform.position + (Vector3)(direction * 0.5f),Quaternion.identity);
         
         bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
            
        }
    }
    IEnumerator ModuleShoot()
    {
        if(Input.GetMouseButtonDown(1) & moduleShooting == true)
        {
            moduleSoundEffect.clip = ModuleSound;
            moduleSoundEffect.PlayOneShot(ModuleSound);
            
        
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 direction = (Vector2)((worldMousePos - transform.position));
         direction.Normalize();
         
         GameObject moduleReal = (GameObject)Instantiate(module, transform.position + (Vector3)(direction * 0.5f),Quaternion.identity);
         
         moduleReal.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

         moduleShooting = false;

         yield return new WaitForSeconds(3);

         moduleShooting = true;


            
        
        }
        

    }
    
}
