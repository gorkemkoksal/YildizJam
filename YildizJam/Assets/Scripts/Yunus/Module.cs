using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    [SerializeField] private GameObject moduleGun;

    Rigidbody2D rb;

    public event Action OnModule;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            Destroy(gameObject);
            OnModule?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

}
