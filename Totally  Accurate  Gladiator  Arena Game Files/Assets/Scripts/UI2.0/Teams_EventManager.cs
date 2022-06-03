using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teams_EventManager : MonoBehaviour
{
    public static Teams_EventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<string, string, string, string, string> onHasKilled;
    public void HasKilled(string killer, string killerteam, string weapon, string killed, string killedteam)
    {
        if (onHasKilled != null)
        {
            onHasKilled(killer, killerteam, weapon, killed, killedteam);
        }
    }

    public event Action<string, string, string> onWeaponUsed;
    public void WeaponUsed(string team, string member, string weapon)
    {
        if (onWeaponUsed != null)
        {
            onWeaponUsed(team, member, weapon);
        }
    }

    public event Action<string> onStatueCaptures;
    public void StatueCaptures(string team)
    {
        if (onStatueCaptures != null)
        {
            onStatueCaptures(team);
        }
    }

    public event Action<string> onStatueStatus;
    public void StatueStatus(string team)
    {
        if (onStatueStatus != null)
        {
            onStatueStatus(team);
        }
    }
}
