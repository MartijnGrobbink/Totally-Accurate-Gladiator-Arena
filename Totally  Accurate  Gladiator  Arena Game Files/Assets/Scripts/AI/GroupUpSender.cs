using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupUpSender : StateMachineBehaviour
{
    private WalkToPosition WTP;
    private AIData data;
    [SerializeField] float timer;
    [SerializeField] float statueGroupDistance;
    public GameObject[] characters;
    private GameObject thisAI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();
        data = animator.gameObject.GetComponent<AIData>();
        characters = GameObject.FindGameObjectsWithTag(animator.gameObject.tag);
        if(data.statue != null)
        WTP.Walk(data.agent, data.statue.transform);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (data.statue != null)
        {
            float dist = (data.agent.transform.position - data.statue.transform.position).magnitude;
            if (dist < statueGroupDistance)
            {
                WTP.StopWalking(data.agent);

                if (timer > 0)
                {
                    for (int i = 0; i < characters.Length; i++)
                    {
                        thisAI = animator.gameObject;
                        CheckForParents(characters[i]);
                    }
                }
                else
                {
                    if (animator.GetBool("AttackStatue") != true)
                    {
                        for (int i = 0; i < characters.Length; i++)
                        {
                            AIData localData;
                            if (characters[i] != null)
                            {
                                if (characters[i].transform.parent != null)
                                    localData = characters[i].GetComponent<AIData>();
                                else
                                    localData = characters[i].GetComponent<AIData>();

                                if (localData != null)
                                {
                                    if (localData.heldWeapon != null && characters[i] != animator.gameObject)
                                    {
                                        localData.GetComponent<Animator>().SetBool("AttackStatue", true);
                                    }
                                    localData.signalSender = null;
                                }
                            }
                        }
                        animator.SetBool("AttackStatue", true);
                    }
                }
                timer -= Time.deltaTime;
            }
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    private void CheckForParents(GameObject rangeCheck)
    {
        if (rangeCheck != null)
        {
            if (rangeCheck.transform.parent == null)
                rangeCheck.GetComponent<AIData>().signalSender = thisAI;
            else
                rangeCheck.GetComponentInParent<AIData>().signalSender = thisAI;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //animator.SetBool("AttackStatue", false);
    }
}


