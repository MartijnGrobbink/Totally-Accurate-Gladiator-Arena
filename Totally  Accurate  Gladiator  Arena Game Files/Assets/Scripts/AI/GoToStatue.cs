using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStatue : StateMachineBehaviour
{
    private WalkToPosition WTP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();

        Transform position = animator.gameObject.GetComponent<AIData>().Statue.transform;
        AIData data = animator.gameObject.GetComponent<AIData>();
        WTP.Walk(data.agent, position);
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
