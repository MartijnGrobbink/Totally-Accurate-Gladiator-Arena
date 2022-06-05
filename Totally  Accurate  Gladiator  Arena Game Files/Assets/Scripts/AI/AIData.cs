using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIData : MonoBehaviour
{
    public Transform teamBase;
    public Transform firstCrossing;
    public NavMeshAgent agent;

    public string MemberName;

    public GameObject Sender;
    public GameObject Statue;

    [HideInInspector] public Transform lastDestination;
    [HideInInspector] public Transform currentDestination;
    [HideInInspector] public Transform nextDestination;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Statue = GameObject.FindGameObjectWithTag("Statue");
    }

    
    void Update()
    {
        
    }
}
