using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Launcher Launcher { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public GameObject NormalBullet { get; private set; }
    [field: SerializeField] public Rigidbody2D PlayerRb { get; private set; }
    [field: SerializeField] public float[] MovementSpeed { get; private set; } = new float[] { 3, 5, 7 };
    [field: SerializeField] public float[] JumpPower { get; private set; } = new float[] { 3, 5, 7 };
    [field: SerializeField] public GameObject[] SpecialWeapons { get; private set; }

    private void Start()
    {
        SwitchState(new RunState(this,1));
    }
    public void Yaz(string something)
    {
        print(something);
    }
}
