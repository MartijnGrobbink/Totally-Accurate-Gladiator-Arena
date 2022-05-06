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
        }
    }

    private void FieldOfViewCheck()
    {
        //look if target is with in circle range
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            Debug.Log(rangeChecks[i].name);
            CheckInView(rangeChecks[i]);
        }
        if(objectsInView.Count != 0)
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
                if(objectsInView.Contains(interactable.gameObject) != true)
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
            if(dist > radius)
            {
                objectsInView.Remove(objectsInView[i].gameObject);
            }
        }
    }
}