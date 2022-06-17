using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchWeapon : StateMachineBehaviour
{
    AIData data;
    WalkToPosition movement;
    private bool nextDestinationChosen;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data = animator.gameObject.GetComponent<AIData>();
        movement = animator.gameObject.GetComponent<WalkToPosition>();

        if (data.nextDestination == null)
        {
            data.nextDestination = data.firstCrossing;
            nextDestinationChosen = true;
        }

        movement.Walk(data.agent, data.nextDestination);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement.currentDistance < 3f)
        {
            if (nextDestinationChosen == true)
            {
                movement.StopWalking(data.agent);
                nextDestinationChosen = false;

                data.lastDestination = data.currentDestination;
                data.currentDestination = data.nextDestination;

                Crossing chooseDestination = data.nextDestination.GetComponent<Crossing>();
                ChooseNextDestination(chooseDestination);
            }
        }
        else
            nextDestinationChosen = true;
    }

    private void ChooseNextDestination(Crossing crossing)
    {
        int random = Random.Range(0, crossing.nextCrossings.Count);

        SetDestination(crossing, random);
    }

    private void SetDestination(Crossing crossing, int i)
    {
        data.nextDestination = crossing.nextCrossings[i].transform;
        if(data.nextDestination != data.lastDestination)
        {
        movement.Walk(data.agent, data.nextDestination);
        }
        else
        {
            ChooseNextDestination(crossing);
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
