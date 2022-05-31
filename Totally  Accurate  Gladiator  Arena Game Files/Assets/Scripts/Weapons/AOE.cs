using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    //---------------------------------------------------Variables---------------------------------------------------------------
    private WeaponStats weapons;
    private bool DealDamage;
    private bool Attacked;
    public GameObject EnemyAttacked;


    //----------------------------------------------Start and Update-------------------------------------------------------------
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    //---------------------------------------------------------------------------------------------------------------------------
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered collision");
        if (DealDamage == false && Attacked == true)
        {
            var x = gameObject.transform.parent;
            if (x.gameObject.tag != other.gameObject.tag)
            {
                EnemyAttacked = other.gameObject;

                DealDamage = true;
            }
        
        }  
        //if can attack == true & in range of AOE 
            //call attack as well for them but only deal damage (private serielizedfield)
            //call damage value from weaponstats for the 
    }

    private void CheckInRange()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            if (inRange.Contains(rangeChecks[i].gameObject) != true && rangeChecks[i].gameObject != gameObject && rangeChecks[i].tag != "Weapon")
                inRange.Add(rangeChecks[i].gameObject);
        }
        CheckIfStillInRange();
    }

    private void CheckIfStillInRange()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            float dist = (gameObject.transform.position - inRange[i].transform.position).magnitude;
            if (dist > radius)
            {
                inRange.Remove(inRange[i].gameObject);
            }
        }
    }
}


