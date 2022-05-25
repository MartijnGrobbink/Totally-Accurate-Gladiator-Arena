using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIData : MonoBehaviour
{
    public List<GameObject> Teams = new List<GameObject>();
    public Transform teamBase;
    public Transform firstCrossing;
    public NavMeshAgent agent;

    [HideInInspector] public Transform lastDestination;
    [HideInInspector] public Transform currentDestination;
    [HideInInspector] public Transform nextDestination;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }
}
