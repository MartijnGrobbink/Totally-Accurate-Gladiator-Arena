using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    //---------------------------------------------------Variables---------------------------------------------------------------

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
        //check if is not same tag
        //if can attack == true & in range of AOE 
            //call attack as well for them but only deal damage (private serielizedfield)
            //call damage value from weaponstats for the 
    }
}
