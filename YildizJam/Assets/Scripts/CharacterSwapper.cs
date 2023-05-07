using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSwapper : MonoBehaviour
{
    //public static CharacterSwapper Instance;
    //[SerializeField] PlayerStateMachine pStateMachine;
    //private void Awake()
    //{
    //    if(Instance == null)
    //    {
    //        Instance = this;
    //    }
    //}
    //public void SwapCharacter(int characterIndex)
    //{
    //    if (SceneManager.GetActiveScene().buildIndex == 1)
    //    {
    //        pStateMachine.SwitchState(new RunState(pStateMachine, 1));
    //    }
    //    else if (SceneManager.GetActiveScene().buildIndex == 2)
    //    {
    //        if (characterIndex == 0)
    //        {
    //            pStateMachine.SwitchState(new RunState(pStateMachine, 1));
    //        }
    //        else
    //        {
    //            pStateMachine.SwitchState(new RunState(pStateMachine, 0));
    //        }
    //    }
    //    else if (SceneManager.GetActiveScene().buildIndex >= 3)
    //    {
    //        var random = Random.Range(0, 3);
    //        while (random == characterIndex)
    //        {
    //            random = Random.Range(0, 3);
    //        }
    //        pStateMachine.SwitchState(new RunState(pStateMachine, random));
    //    }
    //}
}
