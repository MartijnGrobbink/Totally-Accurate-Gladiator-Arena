using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewFilter : MonoBehaviour
{
    public List<GameObject> Ally;
    public List<GameObject> Enemies;
    public List<GameObject> Weapons;

    public void FOVFilter(List<GameObject> rawData)
    {
        for (int i = 0; i < rawData.Count; i++)
        {
            if (rawData[i].tag == gameObject.tag)
            {
                Ally.Add(rawData[i]);
            }
            else if (rawData[i].CompareTag("Weapon"))
            {
                Weapons.Add(rawData[i]);
            }
            else
            {
                Enemies.Add(rawData[i]);
            }
        }
        CheckIfStillSeen(rawData);
    }

    private void CheckIfStillSeen(List<GameObject> rawData)
    {
        for (int i = 0; i < Ally.Count; i++)
        {
            if(rawData.Contains(Ally[i]) == false)
            {
                Ally.Remove(Ally[i]);
            }
        }
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (rawData.Contains(Weapons[i]) == false)
            {
                Weapons.Remove(Weapons[i]);
            }
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (rawData.Contains(Enemies[i]) == false)
            {
                Enemies.Remove(Enemies[i]);
            }
        }
    }
}
