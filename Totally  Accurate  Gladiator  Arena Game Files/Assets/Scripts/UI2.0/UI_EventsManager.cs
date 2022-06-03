using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EventsManager : MonoBehaviour
{
    public static UI_EventsManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<string> onTeamActive;
    public void TeamActive(string team)
    {
        if (onTeamActive != null)
        {
            onTeamActive(team);
        }
    }
}
