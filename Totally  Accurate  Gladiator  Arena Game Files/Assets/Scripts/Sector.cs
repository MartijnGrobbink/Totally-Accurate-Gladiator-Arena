using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{

    public int points = 0;

    public bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        triggered = !triggered;
    }

    public void AddPoints(int changePoints)
    {
        points += changePoints;

    }

    public int GetPoints()
    {
        return points;
    }
}
