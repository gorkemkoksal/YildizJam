using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    //private readonly int JumpHash = Animator.StringToHash("Jump");
    private bool isWallTouched;
    public JumpState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex) {  }
    public override void Enter()
    {
        Jump(characterIndex);
        stateMachine.GroundChecker.IsGrounded = false;
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);

    }
    public override void Exit() { }
    public override void FixedTick(float fixedDeltatime)
    {
        // Move(new Vector3(Input.GetAxis("Horizontal"), stateMachine.transform.position.y), characterIndex);
        //  MoveInput.GetAxis("Horizontal"), 0), characterIndex);
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }
    public override void OnTriggerEnter(Collider other) { }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.PlayerRb.velocity.y == 0 && stateMachine.GroundChecker.IsGrounded)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
    }
    private void Jump(int characterIndex)
    {
        stateMachine.PlayerRb.velocity += new Vector2(0, stateMachine.JumpPower[characterIndex]);
        stateMachine.Yaz("nasilolum,");
    }
}
