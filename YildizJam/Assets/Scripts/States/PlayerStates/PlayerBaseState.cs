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
    protected void Move(Vector3 input, int characterIndex)
    {
        stateMachine.PlayerRb.MovePosition(stateMachine.transform.position + input * stateMachine.MovementSpeed[characterIndex] * Time.fixedDeltaTime);
    }
    protected void Jump(int characterIndex)
    {
        stateMachine.PlayerRb.AddForce(new Vector2(stateMachine.PlayerRb.velocity.x, stateMachine.JumpPower[characterIndex]));

    }
}
