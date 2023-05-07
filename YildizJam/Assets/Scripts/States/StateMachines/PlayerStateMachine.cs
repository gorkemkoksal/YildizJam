using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Launcher Launcher { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public PortalScript PortalScript { get; private set; }
    [field: SerializeField] public GameObject NormalBullet { get; private set; }
    [field: SerializeField] public Rigidbody2D PlayerRb { get; private set; }
    [field: SerializeField] public float[] MovementSpeed { get; private set; } = new float[] { 3, 5, 7 };
    [field: SerializeField] public float[] JumpPower { get; private set; } = new float[] { 3, 5, 7 };
    [field: SerializeField] public float KnockBackDuration { get; private set; }
    [field: SerializeField] public float CoyotaTime { get; private set; } = 0.2f;
    public float CoyotaTimeCounter = 0f;
    [field: SerializeField] public float JumpBufferTime { get; private set; } = 0.3f;
    public float JumpBufferCounter = 0f;
    [field: SerializeField] public Vector2 KnockBackForce { get; private set; }

    [field: SerializeField] public GameObject[] SpecialWeapons { get; private set; }

    private void Start()
    {
        SwitchState(new RunState(this, 0));

    }
    public void Yaz(string something)
    {
        print(something);
    }
}
