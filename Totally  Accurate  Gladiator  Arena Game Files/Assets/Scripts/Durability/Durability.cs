using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public float maxDurability = 30.0f;  // max durability
    public float curDurability;   // current durability

    void Start()
    {
        curDurability = maxDurability;  
    }

    public void HitSomething()
    {
        curDurability -= 5; 

        if (curDurability <= 0)
            Destroy(gameObject);
        {
         
        }
    }
}
