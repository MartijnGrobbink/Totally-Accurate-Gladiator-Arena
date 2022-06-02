using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{

    private int points = 0;
    public Transform sectorCamera; 
    public bool triggered = false;
    private string tag;
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
        triggered = !triggered;
  
        tag = other.tag;  
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
