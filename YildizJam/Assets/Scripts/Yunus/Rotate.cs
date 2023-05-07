using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour

{
    private Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.position;
        float angle  = Mathf.Atan2(direction.y ,direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        gun.rotation = rotation;
    }
}
