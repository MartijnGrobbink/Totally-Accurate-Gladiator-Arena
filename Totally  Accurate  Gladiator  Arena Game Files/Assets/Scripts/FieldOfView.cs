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

    public List<GameObject> Ally;
    public List<GameObject> Enemies;
    public List<GameObject> Weapons;
    // Start is called before the first frame update
    private void Start()
    {
        //targetRef = GameObject.FindGameObjectWithTag("Player");
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
            FieldOfViewCheck();
            if (objectsInView.Count != 0)
                FOVFilter(objectsInView);
        }
    }

    private void FieldOfViewCheck()
    {
        //look if target is with in circle range
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            CheckInView(rangeChecks[i]);
        }
        if (objectsInView.Count != 0)
            CheckIfStillInRange();
    }
    private void CheckInView(Collider interactable)
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
                if (objectsInView.Contains(interactable.gameObject) != true && interactable.gameObject != gameObject)
                    objectsInView.Add(interactable.gameObject);
            }
            else
            {
                objectsInView.Remove(interactable.gameObject);
            }
        }
        else
        {
            objectsInView.Remove(interactable.gameObject);
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

            if (rawData[i].tag == gameObject.tag && Ally.Contains(rawData[i]) != true)
            {
                Ally.Add(rawData[i]);
            }
            else if (rawData[i].CompareTag("Weapon") && Weapons.Contains(rawData[i]) != true)
            {
                Weapons.Add(rawData[i]);
            }
            else if (Enemies.Contains(rawData[i]) != true && Weapons.Contains(rawData[i]) != true && Ally.Contains(rawData[i]) != true)
            {
                Enemies.Add(rawData[i]);
            }
        }
        CheckIfStillSeen(rawData);
    }

    private void CheckIfStillSeen(List<GameObject> rawData)
    {
        for (int i = 0; i < Ally.Count; i++)
        {
            if (rawData.Contains(Ally[i]) == false)
            {
                Ally.Remove(Ally[i]);
            }
        }
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (rawData.Contains(Weapons[i]) == false)
            {
                Weapons.Remove(Weapons[i]);
            }
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (rawData.Contains(Enemies[i]) == false)
            {
                Enemies.Remove(Enemies[i]);
            }
        }
    }
}