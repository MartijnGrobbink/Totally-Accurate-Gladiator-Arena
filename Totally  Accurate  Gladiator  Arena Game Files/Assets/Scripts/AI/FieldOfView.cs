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

    //For every 0.2s check for changes
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

    //Check if the items are in the fiew range
    private void RangeCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            CheckForParents(rangeChecks[i].gameObject);
        }

        if (objectsInView.Count != 0)
            CheckIfStillInRange();
    }

    private void CheckForParents(GameObject rangeCheck)
    {
        if (rangeCheck.transform.parent == null)
        {
            if (objectsInView.Contains(rangeCheck.gameObject) != true)
                CheckInView(rangeCheck.gameObject);
        }
        else
            CheckForParents(rangeCheck.transform.parent.gameObject);

    }

    //Check if the objects are in the triangle
    private void CheckInView(GameObject interactable)
    {
        Transform target = interactable.transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

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

    //Check if the objects are still in the circle
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
        //CheckInLayer();
    }

    private void CheckInLayer()
    {
        //for (int i = 0; i < objectsInView.Count; i++)
        //{
        //    if ((targetMask & (1 << objectsInView[i].layer)) != 0)
        //    {
        //        Debug.Log(objectsInView[i].layer);
        //        objectsInView.RemoveAt(i);
        //    }
        //}
    }

    //Transfer the raw data to the three lists
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

    //Check if the items in the three lists are still in the rawData
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