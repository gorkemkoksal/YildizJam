using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected int characterIndex;

    //protected const float AnimatorDampTime = 0.1f;
    //protected const float CrossFadeDuration = 0.1f;
    public PlayerBaseState(PlayerStateMachine stateMachine, int characterIndex)
    {
        this.stateMachine = stateMachine;
        this.characterIndex = characterIndex;
    }
    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void Move(float input, int characterIndex)
    {
        stateMachine.PlayerRb.velocity = new Vector2(input * stateMachine.MovementSpeed[characterIndex], stateMachine.PlayerRb.velocity.y);
    }
    protected void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(stateMachine.PlayerRb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            stateMachine.transform.localScale = new Vector2(Mathf.Sign(stateMachine.PlayerRb.velocity.x), 1f);
        }
    }
    protected void Jump(int characterIndex, int wallDir = 0)
    {
        stateMachine.PlayerRb.velocity += new Vector2(wallDir * 4f, stateMachine.JumpPower[characterIndex]);     // burasi guncellenebilir
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.transform.position.x > stateMachine.transform.position.x)
            {
                stateMachine.SwitchState(new KnockbackState(stateMachine, characterIndex, -1));
            }
            else
            {
                stateMachine.SwitchState(new KnockbackState(stateMachine, characterIndex, +1));
            }
        }
    }
}
