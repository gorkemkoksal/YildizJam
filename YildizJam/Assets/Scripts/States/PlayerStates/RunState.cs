using UnityEngine;

public class RunState : PlayerBaseState
{
    //private readonly int MovementBlendTreeHash = Animator.StringToHash("MovementBlendTree");
    //private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");
    public RunState(PlayerStateMachine stateMachine, int characterIndex) : base(stateMachine, characterIndex) { }
    public override void Enter()
    {
        stateMachine.CoyotaTimeCounter = stateMachine.CoyotaTime;
        //  stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
        stateMachine.GroundChecker.OnFalling += OnFall;
        stateMachine.PortalScript.OnChange += SwapCharacter;
    }
    public override void Exit()
    {
        stateMachine.GroundChecker.OnFalling -= OnFall;
        stateMachine.PortalScript.OnChange -= SwapCharacter;
    }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.JumpBufferCounter = stateMachine.JumpBufferTime;
        }
        else
        {
            stateMachine.JumpBufferCounter -= Time.deltaTime;
        }
        //if (Input.GetKeyDown(KeyCode.Space) && stateMachine.GroundChecker.IsGrounded)
        //if (Input.GetKeyDown(KeyCode.Space) && stateMachine.CoyotaTimeCounter > 0)
        if (Input.GetKeyDown(KeyCode.Space) && stateMachine.JumpBufferCounter > 0)
        {
            stateMachine.SwitchState(new JumpState(stateMachine, characterIndex));
        }
    }
    private void OnFall()
    {
        stateMachine.SwitchState(new FallingState(stateMachine, characterIndex));
        stateMachine.Yaz("fallingstate");
    }
}
