using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded=true;
    private bool isStillFalling;
    public float platformHeight;
    public event Action OnFalling;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            IsGrounded = true;
            platformHeight = collision.transform.position.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Surface"))
        {
            IsGrounded = false;         
        }
    }
    private void Update()
    {
        if (platformHeight - transform.position.y > 0.5f && !IsGrounded && !isStillFalling)
        {
            isStillFalling = true;
            OnFalling?.Invoke();
        }
    }
}
