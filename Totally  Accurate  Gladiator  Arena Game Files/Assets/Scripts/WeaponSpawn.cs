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
    public GameObject position20;

    List<GameObject> defaultWeapons = new List<GameObject>();
    List<GameObject> positions = new List<GameObject>();

    List<GameObject> weapons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        defaultWeapons.Add(axe);
        defaultWeapons.Add(fish);
        defaultWeapons.Add(sword);
        defaultWeapons.Add(shield);
        defaultWeapons.Add(keyboard);
        defaultWeapons.Add(club);
        defaultWeapons.Add(chikkie);

        positions.Add(position1);
        positions.Add(position2);
        positions.Add(position3);
        positions.Add(position4);
        positions.Add(position5);
        positions.Add(position6);
        positions.Add(position7);
        positions.Add(position8);
        positions.Add(position9);
        positions.Add(position10);
        positions.Add(position11);
        positions.Add(position12);
        positions.Add(position13);
        positions.Add(position14);
        positions.Add(position15);
        positions.Add(position16);
        positions.Add(position17);
        positions.Add(position18);
        positions.Add(position19);
        positions.Add(position20);

        spawnWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnWeapons()
    {
        var random = new System.Random();
        
        for(int i = 0; i < positions.Count; i++){
            // check if there's already a weapon in that position 
            // if(weapons[i] == null) 
            // {
                // create an entirely new object in the same spot as position
                weapons.Insert(i, Instantiate(defaultWeapons[random.Next(0, defaultWeapons.Count)], positions[i].transform.position, positions[i].transform.rotation));
            // }
        }
    } 
    
    // public void destroyWeapon() 
    // {
    //     Destroy(weapons[0].gameObject);
    //     weapons[0] = null;
    // }
}
