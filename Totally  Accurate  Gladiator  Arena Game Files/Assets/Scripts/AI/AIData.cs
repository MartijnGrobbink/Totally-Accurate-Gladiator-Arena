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

    public List<GameObject> enemies;
    public List<GameObject> weapons;
    public List<GameObject> ally;

    public GameObject statue;

    public GameObject heldWeapon;

    public GameObject chosenWeapon;
    public GameObject chosenEnemy;

    public GameObject signalSender;

    public float attackRange;

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
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //{
        //    if (gameObject.transform.GetChild(i).CompareTag("Weapon") == true)
        //        return;
        //    else if (i == gameObject.transform.childCount - 1)
        //        heldWeapon = null;
        //}
    }
}
