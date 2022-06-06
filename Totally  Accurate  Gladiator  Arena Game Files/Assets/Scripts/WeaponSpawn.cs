using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject axe;
    public GameObject fish;
    public GameObject sword;
    public GameObject shield;
    public GameObject keyboard;
    public GameObject club;
    public GameObject chikkie;

    public GameObject position0;
    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;
    public GameObject position5;
    public GameObject position6;
    public GameObject position7;
    public GameObject position8;
    public GameObject position9;
    public GameObject position10;
    public GameObject position11;
    public GameObject position12;
    public GameObject position13;
    public GameObject position14;
    public GameObject position15;
    public GameObject position16;
    public GameObject position17;
    public GameObject position18;
    public GameObject position19;

    List<GameObject> defaultWeapons = new List<GameObject>();
    List<GameObject> positions = new List<GameObject>();

    List<GameObject> weapons = new List<GameObject>();

    public float radius;
    [SerializeField] private LayerMask targetMask;

    //----------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        defaultWeapons.Add(fish);
        defaultWeapons.Add(sword);
        defaultWeapons.Add(shield);
        defaultWeapons.Add(keyboard);
        defaultWeapons.Add(club);
        defaultWeapons.Add(chikkie);

        positions.Insert(0, position0);
        positions.Insert(1, position1);
        positions.Insert(2, position2);
        positions.Insert(3, position3);
        positions.Insert(4, position4);
        positions.Insert(5, position5);
        positions.Insert(6, position6);
        positions.Insert(7, position7);
        positions.Insert(8, position8);
        positions.Insert(9, position9);
        positions.Insert(10, position10);
        positions.Insert(11, position11);
        positions.Insert(12, position12);
        positions.Insert(13, position13);
        positions.Insert(14, position14);
        positions.Insert(15, position15);
        positions.Insert(16, position16);
        positions.Insert(17, position17);
        positions.Insert(18, position18);
        positions.Insert(19, position19);

        spawnWeapons();
        InvokeRepeating(nameof(CheckWeaponInRange), 5f, 5f);
    }

    
    void Update()
    {
        
    }
    
    //----------------------------------------------------------------------------------------------------------------------
    
    // for each of the 20 default positions, spawn a random weapon on that spot
    public void spawnWeapons()
    {
        var random = new System.Random();
        
        for(int i = 0; i < positions.Count; i++){
            Instantiate(defaultWeapons[random.Next(0, defaultWeapons.Count)], positions[i].transform.position, positions[i].transform.rotation);
        }
    } 

    // for each of the 20 default positions, check for any collider in range of a 0.5f radius sphere 
    // if there isn't any collider (gameobject) within that range, create a new random weapon on that specific empty position
    public void CheckWeaponInRange()
    {
        var random = new System.Random();

        for(int i = 0; i < positions.Count; i++){
            Collider[] rangeChecks = Physics.OverlapSphere(positions[i].transform.position, 0.5f, Physics.AllLayers);
            if(rangeChecks.Length == 0){
                Instantiate(defaultWeapons[random.Next(0, defaultWeapons.Count)], positions[i].transform.position, positions[i].transform.rotation);
            }
        }
    }

}
