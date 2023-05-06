using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    //private readonly int MovementBlendTreeHash = Animator.StringToHash("MovementBlendTree");
    //private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");

    private event Action onJump;
    public RunState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex)
    {
    }

    public override void Enter()
    {
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
        onJump += OnJump;
    }

    public override void Exit()
    {
        onJump -= OnJump;
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
        if ((Input.GetKeyDown(KeyCode.Space) && stateMachine.GroundChecker.IsGrounded) || stateMachine.PlayerRb.velocity.y < 0)
        {
            onJump?.Invoke();
        }
        //if (Input.GetAxis("Horizontal") == 0)
        //{
        //    stateMachine.Animator.SetFloat(MovementSpeedHash, 0, AnimatorDampTime, deltaTime);
        //    return;
        //}
        //stateMachine.Animator.SetFloat(MovementSpeedHash, 1, AnimatorDampTime, deltaTime);
    }
    private void OnJump()
    {
        stateMachine.SwitchState(new JumpState(stateMachine, characterIndex));
    }
}
