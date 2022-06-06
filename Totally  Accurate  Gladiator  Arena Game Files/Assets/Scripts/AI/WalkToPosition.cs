using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPosition : MonoBehaviour
{
    public GameObject character;
    //playerController playerController;
    public float currentDistance;
    
    private NavMeshAgent agent;
    private Transform destination;

    void Start()
    {
        //playerController = character.GetComponent<playerController>();
    }

    public void Walk(NavMeshAgent localAgent, Transform walkToPosition)
    {
        agent = localAgent;
        destination = walkToPosition;
        agent.SetDestination(destination.position);
        //playerController.move_forward();
    }

    public void StopWalking(NavMeshAgent agent)
    {
        agent.ResetPath();
        Reset();
    }

    private void Update()
    {
        if(destination != null)
        {
            float dist = (agent.transform.position - destination.position).magnitude;
            currentDistance = dist;
            if (dist < 1.5f)
            {
                InRangeOfPosition();
                agent.ResetPath();
            }
        }
    }

    private void Reset()
    {
        
    }

    protected virtual void InRangeOfPosition()
    {
        Reset();
    }
}