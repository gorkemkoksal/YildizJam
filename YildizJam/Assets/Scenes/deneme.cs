using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("dene");
            //rb.AddForce(new Vector3(0, 10, 0));
            rb.DOMoveY(transform.position.y + 2, 1f);
        }
    }
}
