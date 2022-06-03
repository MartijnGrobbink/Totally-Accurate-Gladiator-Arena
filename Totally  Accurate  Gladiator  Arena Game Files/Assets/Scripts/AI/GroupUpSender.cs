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

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();
        data = animator.gameObject.GetComponent<AIData>();
        characters = GameObject.FindGameObjectsWithTag(animator.gameObject.tag);

        WTP.Walk(data.agent, data.statue.transform);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dist = (data.agent.transform.position - data.statue.transform.position).magnitude;
        if (dist < statueGroupDistance)
        {
            WTP.StopWalking(data.agent);

            if (timer >= 0)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    characters[i].GetComponent<AIData>().signalSender = animator.gameObject;
                }
            }

            timer -= Time.deltaTime;
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
