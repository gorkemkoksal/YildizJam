using UnityEngine;

public class RunState : PlayerBaseState
{
    //private readonly int MovementBlendTreeHash = Animator.StringToHash("MovementBlendTree");
    //private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");
    public RunState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex) { }
    public override void Enter()
    {
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
    }
    public override void Exit() { }
    public override void FixedTick(float fixedDeltatime)
    {
        Move(Input.GetAxis("Horizontal"), characterIndex);
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    public override void Tick(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Space) && stateMachine.GroundChecker.IsGrounded)
        {
            stateMachine.SwitchState(new JumpState(stateMachine, characterIndex));
        }
    }
}
