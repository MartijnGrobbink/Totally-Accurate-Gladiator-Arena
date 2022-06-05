using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeaponState : StateMachineBehaviour
{
    private AIData data;
    private GrabWeapon grab;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data = animator.gameObject.GetComponent<AIData>();
        grab = animator.gameObject.GetComponent<GrabWeapon>();

        if (data.chosenWeapon == null)
            animator.SetInteger("State", 1);
        else
            grab.WalkToItem(data.chosenWeapon);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < data.weapons.Count; i++)
        {
            if (data.weapons[i] == data.chosenWeapon)
                return;
            else if (i + 1 == data.weapons.Count)
            data.chosenWeapon = null;
        }

        if (data.chosenWeapon == null && data.heldWeapon == null)
            animator.SetInteger("State", 1);
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
