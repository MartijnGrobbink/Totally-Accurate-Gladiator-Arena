using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStatue : StateMachineBehaviour
{
    private WalkToPosition WTP;
    private AIData data;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();
        data = animator.gameObject.GetComponent<AIData>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (data.statue != null)
            WTP.Walk(data.agent, data.statue.transform);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
