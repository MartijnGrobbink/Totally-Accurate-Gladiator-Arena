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

        if (data.currentDestination == null)
        {
            data.currentDestination = data.firstCrossing;
            nextDestinationChosen = true;
        }

        movement.Walk(data.agent, data.currentDestination);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (movement.currentDistance < 1.5f)
        {
            if (nextDestinationChosen == true)
            {
                movement.StopWalking(data.agent);
                nextDestinationChosen = false;

                Crossing chooseDestination = data.currentDestination.GetComponent<Crossing>();
                ChooseNextDestination(chooseDestination);
            }
        }
    }

    private void ChooseNextDestination(Crossing crossing)
    {
        int random = Random.Range(0, crossing.nextCrossings.Count);

        if (crossing.nextCrossings[random] != data.lastDestination)
        {
            SetDestination(crossing, random);
        }
        else if (random != crossing.nextCrossings.Count)
        {
            SetDestination(crossing, random + 1);
        }
        else
            SetDestination(crossing, 0);
    }

    private void SetDestination(Crossing crossing, int i)
    {
        data.lastDestination = data.currentDestination;
        data.currentDestination = crossing.nextCrossings[i].transform;

        nextDestinationChosen = true;
        movement.Walk(data.agent, data.currentDestination);
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
