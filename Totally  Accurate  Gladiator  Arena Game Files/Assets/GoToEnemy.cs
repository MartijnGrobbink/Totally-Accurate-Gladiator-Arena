using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToEnemy : StateMachineBehaviour
{
    [SerializeField] float attackDistance;
    private AIData data;
    private WalkToPosition WTP;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data = animator.gameObject.GetComponent<AIData>();
        WTP = animator.gameObject.GetComponent<WalkToPosition>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(data.chosenEnemy != null)
        {
            float dist = (data.agent.transform.position - data.chosenEnemy.transform.position).magnitude;
            if (dist < attackDistance)
                WTP.Walk(data.agent, data.chosenEnemy.transform);
            else
                animator.SetBool("Combat", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
