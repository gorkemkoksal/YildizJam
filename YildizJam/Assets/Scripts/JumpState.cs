using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    //private readonly int JumpHash = Animator.StringToHash("Jump");
    private int jumpCounter;
    private Rigidbody2D playerRb;    
    public JumpState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex)
    {
        playerRb = stateMachine.PlayerRb;
    }
    public override void Enter()
    {
        Jump(characterIndex);
        stateMachine.GroundChecker.IsGrounded = false;
        jumpCounter = 1;
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
        stateMachine.PortalScript.OnChange += SwapCharacter;
<<<<<<< Updated upstream
        stateMachine.Module.OnModule += SwapCharacter;
=======
>>>>>>> Stashed changes
    }
    public override void Exit()
    {
        jumpCounter = 0;
        stateMachine.PortalScript.OnChange -= SwapCharacter;
<<<<<<< Updated upstream
        stateMachine.Module.OnModule -= SwapCharacter;
=======
>>>>>>> Stashed changes
    }
    public override void FixedTick(float fixedDeltatime)
    {
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

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
        stateMachine.CoyotaTimeCounter -= Time.deltaTime;
        if (Input.GetButtonUp("Jump") && stateMachine.PlayerRb.velocity.y > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }

        if (characterIndex == 0 && jumpCounter < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCounter = 2;
            Jump(characterIndex);
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }
        if (stateMachine.GroundChecker.IsGrounded)
        {
            stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
        }
    }

}
