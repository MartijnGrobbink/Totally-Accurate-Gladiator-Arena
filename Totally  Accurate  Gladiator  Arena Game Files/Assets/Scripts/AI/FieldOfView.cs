using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    //sources
    //https://www.youtube.com/watch?v=j1-OyLo77ss
    public float radius;
    [Range(0, 360)]
    public float angle;

    //public GameObject targetRef;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    public List<GameObject> objectsInView;

    private AIData data;

    // Start is called before the first frame update
    private void Start()
    {
        data = gameObject.GetComponent<AIData>();
        StartCoroutine(FOVRoutine());
    }
    //core routing for each 0.2f
    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            RangeCheck();
            if (objectsInView.Count != 0)
                FOVFilter(objectsInView);
            CheckIfStillSeen(objectsInView);
        }
    }

    private void RangeCheck()
    {
        //look if target is with in circle range
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                Transform item = rangeChecks[i].transform.parent;
            if (item != null)
                if (objectsInView.Contains(item.gameObject) != true)
                    CheckInView(item.gameObject);
            }

        if (objectsInView.Count != 0)
            CheckIfStillInRange();
    }
    private void CheckInView(GameObject interactable)
    {
        //set the target to the taget in the circle
        Transform target = interactable.transform;
        //look difference in location from out target
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        //look if the interactable is within the triangle 
        //angle is defided by 2 because half of the triange is positive and the other half is negative

        //NOTE don't forget filter tags so you don't trigger the ai with you own team members
        if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
        {
            //get the distance of the target
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            //look if there is no obstuction
            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
            {
                if (objectsInView.Contains(interactable) != true && interactable != gameObject)
                    objectsInView.Add(interactable);
            }
            else
            {
                objectsInView.Remove(interactable);
            }
        }
        else
        {
            objectsInView.Remove(interactable);
        }
    }
    private void CheckIfStillInRange()
    {
        for (int i = 0; i < objectsInView.Count; i++)
        {
            float dist = (gameObject.transform.position - objectsInView[i].transform.position).magnitude;
            if (dist > radius)
            {
                objectsInView.Remove(objectsInView[i].gameObject);
            }
        }
    }

    private void FOVFilter(List<GameObject> rawData)
    {
        for (int i = 0; i < rawData.Count; i++)
        {

            if (rawData[i].tag == gameObject.tag && data.ally.Contains(rawData[i]) != true)
            {
                data.ally.Add(rawData[i]);
            }
            else if (rawData[i].CompareTag("Weapon") && data.weapons.Contains(rawData[i]) != true)
            {
                data.weapons.Add(rawData[i]);
            }
            else if (data.enemies.Contains(rawData[i]) != true && data.weapons.Contains(rawData[i]) != true && data.ally.Contains(rawData[i]) != true)
            {
                data.enemies.Add(rawData[i]);
            }
        }
    }

    private void CheckIfStillSeen(List<GameObject> rawData)
    {
        if (rawData.Count != 0)
        {
            for (int i = 0; i < data.ally.Count; i++)
            {
                if (rawData.Contains(data.ally[i]) == false)
                {
                    data.ally.Remove(data.ally[i]);
                }
            }
            for (int i = 0; i < data.weapons.Count; i++)
            {
                if (rawData.Contains(data.weapons[i]) == false)
                {
                    data.weapons.Remove(data.weapons[i]);
                }
            }
            for (int i = 0; i < data.enemies.Count; i++)
            {
                if (rawData.Contains(data.enemies[i]) == false)
                {
                    data.enemies.Remove(data.enemies[i]);
                }
            }
        }
        else
        {
            data.ally.Clear();
            data.weapons.Clear();
            data.enemies.Clear();
        }
    }
}