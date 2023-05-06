using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    //private readonly int JumpHash = Animator.StringToHash("Jump");

    public JumpState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex)
    {
    }

    public override void Enter()
    {
        stateMachine.GroundChecker.IsGrounded = false;
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
        Jump(characterIndex);
    }

    public override void Exit()
    {
    }

    public override void FixedTick(float fixedDeltatime)
    {
        Move(new Vector3(Input.GetAxis("Horizontal"), 0, 0), characterIndex);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.PlayerRb.velocity.y == 0)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
    }
}
