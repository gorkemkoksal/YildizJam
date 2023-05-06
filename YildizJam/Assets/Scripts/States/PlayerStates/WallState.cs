using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallState : PlayerBaseState
{

    //private readonly int StickHash = Animator.StringToHash("Stick");
    private float hangTime = 2f;
    private float timer = 0;
    private int wallDir;
    public WallState(PlayerStateMachine stateMachine, int characterIndex, int wallDir) : base(stateMachine, characterIndex)
    {
        this.wallDir = wallDir;
    }
    public override void Enter()
    {
        //  stateMachine.Animator.CrossFadeInFixedTime(StickHash, CrossFadeDuration);
        stateMachine.PlayerRb.velocity = Vector2.zero;
        stateMachine.PlayerRb.isKinematic = true;
    }
    public override void Exit()
    {
        stateMachine.PlayerRb.isKinematic = false;
    }
    public override void FixedTick(float fixedDeltatime) { }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    public override void Tick(float deltaTime)
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(characterIndex, wallDir);
        }

        if (timer > hangTime)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
    }
}
