using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private GroundChecker groundChecker;
    private float verticalVelocity;
    private void Update()
    {
        if (verticalVelocity < 0f && groundChecker.IsGrounded)
        {
            verticalVelocity = Physics2D.gravity.y * Time.deltaTime/20;
        }
        else
        {
            verticalVelocity += Physics2D.gravity.y * Time.deltaTime/20;
        }
    }
    public Vector3 Movement => Vector3.up * verticalVelocity;
}
