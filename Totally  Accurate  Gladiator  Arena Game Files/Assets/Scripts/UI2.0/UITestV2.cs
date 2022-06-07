using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestV2 : MonoBehaviour
{
    public Teams_Data TD;
    public bool haskilled;
    public bool haskilled1;
    public bool hascaptured;
    public bool capturing;
    public bool HOLDER;
    public bool weaponused;
    public bool active;

    public int CJimKills;
    public int CJimDeaths;
    public int CJimWeapons;

    public int KJimKills;
    public int KJimDeaths;
    public int KJimWeapons;

    public int GJimKills;
    public int GJimDeaths;
    public int GJimWeapons;

    public int caxe;
    public int cchicken;
    public int csword;
    public int cshield;
    public int cfish;
    public int ckeyboard;
    public int cclub;

    public int kaxe;
    public int kchicken;
    public int ksword;
    public int kshield;
    public int kfish;
    public int kkeyboard;
    public int kclub;

    public int cgamers;
    public int cromans;
    public int cknights;
    public int cvikings;

    public int kgamers;
    public int kromans;
    public int kknights;
    public int kvikings;

    public int kills;
    public int captures;

    void Start()
    {
        
    }

    
    void Update()
    {
        SetVariables();

        if (HOLDER == true)
        {
            UI_EventsManager.current.TeamActive("Contested");
            HOLDER = false;
        }

        if (active == true)
        {
            UI_EventsManager.current.TeamActive("NoTeam");
            active = false;
        }

        if (capturing == true)
        {
            Teams_EventManager.current.StatueStatus("Cavemen");
            capturing = false;
        }

        if (haskilled == true)
        {
            Teams_EventManager.current.HasKilled("MemberA", "Cavemen", "Axe", "MemberA", "Knights");
            TD.WeaponUses["Cavemen"]["Sword"] = 2;
            TD.WeaponUses["Cavemen"]["Chicken"] = 4;
            haskilled = false;
        }

        if (haskilled1 == true)
        {
            Teams_EventManager.current.HasKilled("MemberB", "Cavemen", "Axe", "Leader", "Gamers");
            TD.WeaponUses["Cavemen"]["Sword"] = 2;
            TD.WeaponUses["Cavemen"]["Chicken"] = 4;
            haskilled1 = false;
        }

        if (weaponused == true)
        {
            Teams_EventManager.current.WeaponUsed("Cavemen", "MemberA", "Club");
            Teams_EventManager.current.WeaponUsed("Cavemen", "MemberB", "Axe");
            Teams_EventManager.current.WeaponUsed("Cavemen", "Leader", "Sword");
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

        KJimKills = TD.CharacterInfo["Knights"]["MemberA"][0];
        KJimDeaths = TD.CharacterInfo["Knights"]["MemberA"][1];
        KJimWeapons = TD.CharacterInfo["Knights"]["MemberA"][2];

        GJimKills = TD.CharacterInfo["Gamers"]["MemberA"][0];
        GJimDeaths = TD.CharacterInfo["Gamers"]["MemberA"][1];
        GJimWeapons = TD.CharacterInfo["Gamers"]["MemberA"][2];

        caxe = TD.WeaponUses["Cavemen"]["Axe"];
        csword = TD.WeaponUses["Cavemen"]["Sword"];
        cshield = TD.WeaponUses["Cavemen"]["Shield"];
        ckeyboard = TD.WeaponUses["Cavemen"]["Keyboard"];
        cfish = TD.WeaponUses["Cavemen"]["Fish"];
        cclub = TD.WeaponUses["Cavemen"]["Club"];
        cchicken = TD.WeaponUses["Cavemen"]["Chicken"];

        kaxe = TD.WeaponUses["Knights"]["Axe"];
        ksword = TD.WeaponUses["Knights"]["Sword"];
        kshield = TD.WeaponUses["Knights"]["Shield"];
        kkeyboard = TD.WeaponUses["Knights"]["Keyboard"];
        kfish = TD.WeaponUses["Knights"]["Fish"];
        kclub = TD.WeaponUses["Knights"]["Club"];
        kchicken = TD.WeaponUses["Knights"]["Chicken"];

        cgamers = TD.OtherTeamsKilled["Cavemen"]["Gamers"];
        cromans = TD.OtherTeamsKilled["Cavemen"]["Romans"];
        cknights = TD.OtherTeamsKilled["Cavemen"]["Knights"];
        cvikings = TD.OtherTeamsKilled["Cavemen"]["Vikings"];

        kgamers = TD.OtherTeamsKilled["Knights"]["Gamers"];
        kromans = TD.OtherTeamsKilled["Knights"]["Romans"];
        kknights = TD.OtherTeamsKilled["Knights"]["Cavemen"];
        kvikings = TD.OtherTeamsKilled["Knights"]["Vikings"];

        kills = TD.ScoreInfo["Cavemen"][0];
        captures = TD.ScoreInfo["Cavemen"][1];
    }
}
