using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupUpSender : StateMachineBehaviour
{
    private WalkToPosition WTP;
    public GameObject[] characters;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();

        characters = GameObject.FindGameObjectsWithTag(animator.gameObject.tag);
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<AIData>().Sender = animator.gameObject;

        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
