using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackState : PlayerBaseState
{
    //private readonly int KnockbackHash = Animator.StringToHash("Knockback");
    private int knockBackDirection;
    private float timer;
    public KnockbackState(PlayerStateMachine stateMachine, int characterIndex, int knockBackDirection) : base(stateMachine, characterIndex)
    {
        this.knockBackDirection = knockBackDirection;
    }
    public override void Enter()
    {
        //  stateMachine.Animator.CrossFadeInFixedTime(KnockbackHash, CrossFadeDuration);
        stateMachine.PlayerRb.velocity = Vector2.zero;
        stateMachine.PlayerRb.AddForce(stateMachine.KnockBackForce * knockBackDirection);            //burasi rakamlar guncellenebilir
    }
    public override void Exit()
    {
        timer = 0;
    }
    public override void FixedTick(float fixedDeltatime) { }
    public override void OnTriggerEnter2D(Collider2D other) { }
    public override void Tick(float deltaTime)
    {
        timer += Time.deltaTime;
        if (timer >= stateMachine.KnockBackDuration)
        {
            if (stateMachine.GroundChecker.IsGrounded)
            {
                stateMachine.SwitchState(new RunState(stateMachine, characterIndex));
            }
            else
            {
                stateMachine.SwitchState(new JumpState(stateMachine, characterIndex));
            }
        }
    }
}
