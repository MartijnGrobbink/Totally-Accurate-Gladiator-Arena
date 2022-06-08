using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueRespawner : MonoBehaviour
{
    public GameObject StatuePrefab;
    public GameObject StatueStart;
    public GameObject Envo;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameObject.FindWithTag("Statue") == null)
        {
            Instantiate(StatuePrefab, StatueStart.transform.position, Quaternion.identity, Envo.transform);
        }
    }
}
