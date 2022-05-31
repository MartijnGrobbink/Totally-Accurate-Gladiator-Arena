using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToEnemy : StateMachineBehaviour
{
    AIData data;
    WalkToPosition movement;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data = animator.gameObject.GetComponent<AIData>();
        movement = animator.gameObject.GetComponent<WalkToPosition>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (data.targetEnemy != null)
        {
            movement.Walk(data.agent, data.targetEnemy.transform);
        }
        else
            Debug.LogError("Wants To Attck Enemy But No Enemy Found");

        if (movement.currentDistance < data.attackRange)
            animator.SetBool("InAttackRange", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movement.StopWalking(data.agent);
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
