using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPosition : MonoBehaviour
{
    public GameObject character;
    playerController pc;
    public float currentDistance;

    private NavMeshAgent agent;
    private Transform destination;

    public void Walk(NavMeshAgent localAgent, Transform walkToPosition)
    {
        agent = localAgent;
        PhysicsCharacterSetUp();

        destination = walkToPosition;
        agent.SetDestination(destination.position);
    }

    private void PhysicsCharacterSetUp()
    {
        character = agent.gameObject;

        pc = character.GetComponentInChildren<playerController>();
        if(pc != null)
            pc.move_forward();
    }

    public void StopWalking(NavMeshAgent agent)
    {
        agent.ResetPath();
        Reset();
        if (character != null)
            pc.moving = false;
    }

    private void Update()
    {
        if (destination != null)
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