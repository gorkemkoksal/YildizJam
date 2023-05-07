using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    //IŞINLANMASINI İSTEDİĞİNİZ GAMEOBJECTIN İÇİNE ATILMASI GEREKN BİR KOD.
    [SerializeField] private GameObject redPortal;
    [SerializeField] private GameObject bluePortal;
    [SerializeField] private GameObject player;

    AudioSource portalSoundEffect;
    public AudioClip prt;

    public event Action OnChange;

    private bool transformation = true;

    void Start()
    {
        portalSoundEffect = GetComponent<AudioSource>();
    }
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
            if ((GameObject.Find("BluePortal(Clone)") != null) & (GameObject.Find("RedPortal(Clone)") != null))
            {
                if (other.gameObject.tag == "RedPortal")
                {
                    if (this.gameObject.tag == "Player")
                    {
                        OnChange?.Invoke();
                    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
                    player.transform.position = GameObject.Find("BluePortal(Clone)").transform.position;
                    portalSoundEffect.clip = prt;
                    portalSoundEffect.Play();
                    transformation = false;
<<<<<<< Updated upstream
                }
                if (other.gameObject.tag == "BluePortal")
                {
=======

                }
                if (other.gameObject.tag == "BluePortal")
                {

>>>>>>> Stashed changes
                    if (this.gameObject.tag == "Player")
                    {
                        OnChange?.Invoke();
                    }
                    player.transform.position = GameObject.Find("RedPortal(Clone)").transform.position;
                    portalSoundEffect.clip = prt;
                    portalSoundEffect.Play();
                    transformation = false;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
                }
            }
        }
    }
    IEnumerator Teleport()
    {
        transformation = false;
        yield return new WaitForSeconds(0.2f);
        transformation = true;
    }
}
