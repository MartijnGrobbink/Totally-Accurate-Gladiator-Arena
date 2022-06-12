using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayState : StateMachineBehaviour
{
    private AIData data;
    private WalkToPosition WTP;
    private Transform crossingHolder;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data = animator.gameObject.GetComponent<AIData>();
        WTP = animator.gameObject.GetComponent<WalkToPosition>();

        WTP.Walk(data.agent, data.lastDestination);

        crossingHolder = data.firstCrossing.parent;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(data.lastDestination != null)
        {
            float dist = (data.agent.transform.position - data.lastDestination.position).magnitude;
            if(dist <= 1.5f)
            {
                int rand = Random.Range(0, crossingHolder.childCount);
                WTP.Walk(data.agent, crossingHolder.GetChild(rand));
                float randDist = (data.agent.transform.position - crossingHolder.GetChild(rand).position).magnitude;
                if(randDist <= 1.5f)
                    animator.SetInteger("State", 1);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("State", 0);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
