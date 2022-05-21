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
        Debug.Log(movement.currentDistance);
        if(movement.currentDistance < 1.5f)
        {

            if (nextDestinationChosen == true)
            {
                nextDestinationChosen = false;
                data.lastDestination = data.currentDestination;

                Crossing chooseDestination = data.currentDestination.GetComponent<Crossing>();
                ChooseNextDestination(chooseDestination);
            }
        }
    }

    private void ChooseNextDestination(Crossing nextCrossing)
    {
        //Debug.Log(nextCrossing);
        int random = Random.Range(0, nextCrossing.nextCrossings.Count);

        if (nextCrossing.nextCrossings[random] != data.lastDestination && nextDestinationChosen == false)
        {
            data.currentDestination = nextCrossing.nextCrossings[random].transform;

            movement.StopWalking(data.agent);

            movement.Walk(data.agent, data.currentDestination);
            nextDestinationChosen = true;
        }
        else
        {
            Crossing chooseDestination = data.lastDestination.GetComponent<Crossing>();
            ChooseNextDestination(chooseDestination);
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
