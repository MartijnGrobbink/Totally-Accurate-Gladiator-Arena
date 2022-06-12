using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sector : MonoBehaviour
{

    private int points = 0;
    public Transform sectorCamera; 
    public bool triggered = false;
    private string tag = "";
    private string[] possibleTags = new string[]{"Gamer", "Viking", "Medieval", "Roman", "Caveman", "Statue"};

    // Starts called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When object enters the sector, it's triggered
    private void OnTriggerEnter(Collider other)
    {   

        GameObject currCollider = other.gameObject; 

        // if the collider is a statue, update the tag
        if(currCollider.tag == "Statue") {
            tag = currCollider.tag;  
        }

        // the sectors are being triggered by the collider of each player's spine
        // to get the tag of the player, we have to get the parent of the parent
        try {
            currCollider = other.transform.parent.gameObject.transform.parent.gameObject;
        } 
        catch (NullReferenceException e)
        {
            // this means that the collider in question is not one of the players, as fetching
            // the parent twice doesn't retrieve the main player GameObject
            // we will ignore these cases
        }

        if (possibleTags.Any(currCollider.tag.Contains)) {
            triggered = !triggered;
        }
    }

    private void OnTriggerExit(Collider other) {
        tag = "";
    }

    public string getColliderTag()
    {
        return tag;
    }   
    
    // Points
    public void AddPoints(int changePoints)
    {
        points += changePoints;
    }

    public int GetPoints()
    {
        return points;
    }

    // Sector Camera
    public Transform getSectorCamera()
    {
        return this.sectorCamera;
    }
}
