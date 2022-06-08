using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ActiveTeam : MonoBehaviour
{
    public List<string> active;
    private float timer = 10f;

    private int passed = -1;
    
    void Start()
    {
        active.Add("NoTeam");
        active.Add("Knights");
        active.Add("Vikings");
        active.Add("Romans");
        active.Add("Cavemen");
        active.Add("Gamers");
    }

    
    void Update()
    {
        if (timer <= 0)
        {
            passed = passed + 1;
            if (passed == active.Count)
            {
                passed = 0;
            }
            UI_EventsManager.current.TeamActive(active[passed]);
            timer = 10f;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
