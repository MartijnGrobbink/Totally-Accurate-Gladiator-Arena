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

    public GameObject signalSender;

    public GameObject chosenWeapon;
    public GameObject chosenEnemy;

    public GameObject heldWeapon;

    public List<GameObject> ally;
    public List<GameObject> enemies;
    public List<GameObject> weapons;

    [HideInInspector] public GameObject statue;

    [HideInInspector] public Transform lastDestination;
    [HideInInspector] public Transform currentDestination;
    [HideInInspector] public Transform nextDestination;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        statue = GameObject.FindGameObjectWithTag("Statue");
    }

    
    void Update()
    {
        
    }
}
