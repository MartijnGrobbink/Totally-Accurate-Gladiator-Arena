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
        if (data.weapons.Count == 0)
        {
            data.chosenWeapon = null;
            if (data.heldWeapon == null)
                animator.SetInteger("State", 1);
        }
        //for (int i = 0; i < data.weapons.Count; i++)
        //{
        //    if (data.weapons[i] == data.chosenWeapon)
        //        return;
        //}
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
