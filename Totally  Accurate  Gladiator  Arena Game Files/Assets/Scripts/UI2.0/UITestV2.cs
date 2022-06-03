using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestV2 : MonoBehaviour
{
    public Teams_Data TD;
    public bool haskilled;
    public bool hascaptured;
    public bool weaponused;
    public bool active;

    public int CJimKills;
    public int CJimDeaths;
    public int CJimWeapons;

    public int axe;
    public int chicken;
    public int sword;
    public int shield;
    public int fish;
    public int keyboard;
    public int club;

    public int gamers;
    public int romans;
    public int knights;
    public int vikings;

    public int kills;
    public int captures;

    void Start()
    {
        
    }

    
    void Update()
    {
        SetVariables();

        if (active == true)
        {
            UI_EventsManager.current.TeamActive("Cavemen");
            active = false;
        }

        if (haskilled == true)
        {
            Teams_EventManager.current.HasKilled("MemberA", "Cavemen", "Axe", "MemberA", "Gamers");
            TD.WeaponUses["Cavemen"]["Sword"] = 2;
            TD.WeaponUses["Cavemen"]["Chicken"] = 3;
            haskilled = false;
        }

        if (weaponused == true)
        {
            Teams_EventManager.current.WeaponUsed("Cavemen", "MemberA", "Club");
            weaponused = false;
        }

        if (hascaptured == true)
        {
            Teams_EventManager.current.StatueCaptures("Cavemen");
            hascaptured = false;
        }
    }

    void SetVariables()
    {
        CJimKills = TD.CharacterInfo["Cavemen"]["MemberA"][0];
        CJimDeaths = TD.CharacterInfo["Cavemen"]["MemberA"][1];
        CJimWeapons = TD.CharacterInfo["Cavemen"]["MemberA"][2];

        axe = TD.WeaponUses["Cavemen"]["Axe"];
        sword = TD.WeaponUses["Cavemen"]["Sword"];
        shield = TD.WeaponUses["Cavemen"]["Shield"];
        keyboard = TD.WeaponUses["Cavemen"]["Keyboard"];
        fish = TD.WeaponUses["Cavemen"]["Fish"];
        club = TD.WeaponUses["Cavemen"]["Club"];
        chicken = TD.WeaponUses["Cavemen"]["Chicken"];

        gamers = TD.OtherTeamsKilled["Cavemen"]["Gamers"];
        romans = TD.OtherTeamsKilled["Cavemen"]["Romans"];
        knights = TD.OtherTeamsKilled["Cavemen"]["Knights"];
        vikings = TD.OtherTeamsKilled["Cavemen"]["Vikings"];

        kills = TD.ScoreInfo["Cavemen"][0];
        captures = TD.ScoreInfo["Cavemen"][1];
    }
}
