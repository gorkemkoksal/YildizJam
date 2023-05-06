using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : PlayerBaseState
{
    private bool isSecondJump;
    public FallingState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex)
    {
    }
    public override void Enter()
    {
    }
    public override void Exit()
    {
        isSecondJump = false;
    }
    public override void FixedTick(float fixedDeltatime)
    {
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.GroundChecker.IsGrounded)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
        if (characterIndex == 0 && !isSecondJump && Input.GetKeyDown(KeyCode.Space))
        {
            isSecondJump = true;
            Jump(characterIndex);
        }
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
