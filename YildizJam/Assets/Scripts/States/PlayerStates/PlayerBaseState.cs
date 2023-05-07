using DG.Tweening;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    protected void SwapCharacter()
    {
        for (int i = 0; i <2; i++)
        {
            stateMachine.Characters[i].SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            characterIndex = 1;
            stateMachine.Characters[1].SetActive(true);
            stateMachine.SwitchState(new RunState(stateMachine, 1));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (characterIndex == 0)
            {
                characterIndex = 1;
                stateMachine.Characters[1].SetActive(true);
                stateMachine.SwitchState(new RunState(stateMachine, 1));
            }
            else
            {
                characterIndex = 0;
                stateMachine.Characters[0].SetActive(true);
                stateMachine.SwitchState(new RunState(stateMachine, 0));
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            var random = Random.Range(0, 3);
            while (random == characterIndex)
            {
                random = Random.Range(0, 3);
            }
            characterIndex = random;
            stateMachine.Characters[random].SetActive(true);
            stateMachine.SwitchState(new RunState(stateMachine, random));
        }
    }
}
