using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPosition : MonoBehaviour
{
    private Coroutine check;
    public float currentDistance;

    public void Walk(NavMeshAgent agent, Transform walkToPosition)
    {
        agent.SetDestination(walkToPosition.position);
        check = StartCoroutine(CheckDistance(walkToPosition, agent, 1.0f));
    }

    public void StopWalking(NavMeshAgent agent)
    {
        agent.ResetPath();
        if(check != null)
            StopCoroutine(check);
    }

    private IEnumerator CheckDistance(Transform position, NavMeshAgent agent, float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);

            float dist = (agent.transform.position - position.position).magnitude;
            currentDistance = dist;
            if (dist < 1f)
            {
                InRangeOfPosition();
                agent.ResetPath();
            }
        }
    }

    protected virtual void InRangeOfPosition()
    {
        StopCoroutine(check);
    }
}