using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    //private readonly int JumpHash = Animator.StringToHash("Jump");
    private int jumpCounter;
    public JumpState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex) { }
    public override void Enter()
    {
        Jump(characterIndex);
        stateMachine.GroundChecker.IsGrounded = false;
        jumpCounter = 1;
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);

    }
    public override void Exit()
    {
        jumpCounter = 0;
    }
    public override void FixedTick(float fixedDeltatime)
    {
        // Move(new Vector3(Input.GetAxis("Horizontal"), stateMachine.transform.position.y), characterIndex);
        //  MoveInput.GetAxis("Horizontal"), 0), characterIndex);
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") && characterIndex == 2)
        {
            if (other.transform.position.x < stateMachine.transform.position.x)
            {
                stateMachine.SwitchState(new WallState(stateMachine, characterIndex, 1));
            }
            else
            {
                stateMachine.SwitchState(new WallState(stateMachine, characterIndex, -1));
            }
        }
    }
    public override void Tick(float deltaTime)
    {
        if (characterIndex == 0 && jumpCounter < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCounter = 2;
            Jump(characterIndex);
        }
        if (stateMachine.PlayerRb.velocity.y == 0 && stateMachine.GroundChecker.IsGrounded)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
    }

}
