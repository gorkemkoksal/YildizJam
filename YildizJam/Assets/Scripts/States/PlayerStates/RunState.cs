using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    //private readonly int MovementBlendTreeHash = Animator.StringToHash("MovementBlendTree");
    //private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");

    public RunState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex)
    {
    }

    public override void Enter()
    {

        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);

    }

    public override void Exit()
    {

    }
    public override void FixedTick(float fixedDeltatime)
    {
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void Tick(float deltaTime)
    {

        if (Input.GetKeyDown(KeyCode.Space) && stateMachine.GroundChecker.IsGrounded)
        {
            // stateMachine.GroundChecker.IsGrounded = false;
            // Jump(characterIndex);
            stateMachine.SwitchState(new JumpState(stateMachine, characterIndex));
        }        
    }
    //private void Jump(int characterIndex)
    //{
    //    stateMachine.PlayerRb.velocity += new Vector2(0, stateMachine.JumpPower[characterIndex]);
    //    stateMachine.Yaz("nasilolum,");
    //}
}
