using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teams_Data : MonoBehaviour
{
    public UI_Members UM;
    public UI_Teams UT;
    public UI_KillFeed UF;

    public Dictionary<string, Dictionary<string, int>> WeaponUses = new Dictionary<string, Dictionary<string, int>>();
   
    public Dictionary<string, Dictionary<string, int>> OtherTeamsKilled = new Dictionary<string, Dictionary<string, int>>();

    public Dictionary<string, Dictionary<string, List<int>>> CharacterInfo = new Dictionary<string, Dictionary<string, List<int>>>();

    public Dictionary<string, List<int>> ScoreInfo = new Dictionary<string, List<int>>();

    public string StatueStatus;
    // NoTeam for contested

    void Start()
    {
        //Subscribing To Events
        Teams_EventManager.current.onHasKilled += MemberHasKilled;
        Teams_EventManager.current.onWeaponUsed += TeamsWeaponUse;
        Teams_EventManager.current.onStatueCaptures += TeamsStatueCaptures;
        Teams_EventManager.current.onStatueStatus += TeamsStatueStatus;
        //--------------------------------------------------------Cavemen------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = axe, 1 = chicken, 2 = sword, 3 = shield, 4 = fish, 5 = keyboard, 6 = club)
        List<int> CharacterDataList00 = new List<int>();
        List<int> CharacterDataList01 = new List<int>();
        List<int> CharacterDataList02 = new List<int>();
        Dictionary<string, List<int>> CharacterData00 = new Dictionary<string, List<int>>();
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterData00.Add("MemberA", CharacterDataList00);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterData00.Add("Leader", CharacterDataList01);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterData00.Add("MemberB", CharacterDataList02);
        CharacterInfo.Add("Cavemen", CharacterData00);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed00 = new Dictionary<string, int>();
        WeaponsUsed00.Add("Axe", 0);
        WeaponsUsed00.Add("Chicken", 0);
        WeaponsUsed00.Add("Sword", 0);
        WeaponsUsed00.Add("Shield", 0);
        WeaponsUsed00.Add("Fish", 0);
        WeaponsUsed00.Add("Keyboard", 0);
        WeaponsUsed00.Add("Club", 0);
        WeaponUses.Add("Cavemen", WeaponsUsed00);
        //Setting OtherTeamsKilled
        Dictionary<string, int> TeamsKilled00 = new Dictionary<string, int>();
        TeamsKilled00.Add("Gamers", 0);
        TeamsKilled00.Add("Vikings", 0);
        TeamsKilled00.Add("Knights", 0);
        TeamsKilled00.Add("Romans", 0);
        OtherTeamsKilled.Add("Cavemen", TeamsKilled00);
        //Setting ScoreInfo - List item 0 is kills total, List item 1 is captures total
        List<int> ScoreData00 = new List<int>();
        ScoreData00.Add(0);
        ScoreData00.Add(0);
        ScoreInfo.Add("Cavemen", ScoreData00);
        //
        //--------------------------------------------------------Gamers------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = axe, 1 = chicken, 2 = sword, 3 = shield, 4 = fish, 5 = keyboard, 6 = club)
        List<int> CharacterDataList03 = new List<int>();
        List<int> CharacterDataList04 = new List<int>();
        List<int> CharacterDataList05 = new List<int>();
        Dictionary<string, List<int>> CharacterData01 = new Dictionary<string, List<int>>();
        CharacterDataList03.Add(0);
        CharacterDataList03.Add(0);
        CharacterDataList03.Add(0);
        CharacterData01.Add("MemberA", CharacterDataList03);
        CharacterDataList04.Add(0);
        CharacterDataList04.Add(0);
        CharacterDataList04.Add(0);
        CharacterData01.Add("Leader", CharacterDataList04);
        CharacterDataList05.Add(0);
        CharacterDataList05.Add(0);
        CharacterDataList05.Add(0);
        CharacterData01.Add("MemberB", CharacterDataList05);
        CharacterInfo.Add("Gamers", CharacterData01);

        /*
        if (WeaponUses.ContainsKey("Cavemen"))
        {
            WeaponUses["Cavemen"]["Axe"] = 2;
            Debug.Log(WeaponUses["Cavemen"]["Axe"]);
        }
        */
        //Debug.Log(OtherTeamsKilled["Cavemen"]["Romans"]);
        /*
        List<int> temp = null;
        if (CharacterInfo.TryGetValue("CavemanJohn", out temp))
        {
            Debug.Log(temp[0]);
        }

        if (CharacterInfo.TryGetValue("CavemanJimmy", out temp))
        {
            Debug.Log(temp[0]);
        }
        */


    }

    private void TeamsStatueStatus(string team)
    {
        StatueStatus = team;
    }

    private void TeamsStatueCaptures(string team) 
    {
        var x = ScoreInfo[team][1];
        int xv = x + 1;
        ScoreInfo[team][1] = xv;
    }

    private void MemberHasKilled(string killer, string killerteam, string weapon, string killed, string killedteam)
    {
        int x = CharacterInfo[killerteam][killer][0];
        int xv = x + 1;
        CharacterInfo[killerteam][killer][0] = xv;

        var y = CharacterInfo[killedteam][killed][1];
        int yv = y + 1;
        CharacterInfo[killedteam][killed][1] = yv;

        var z = OtherTeamsKilled[killerteam][killedteam];
        int zv = z + 1;
        OtherTeamsKilled[killerteam][killedteam] = zv;

        var a = ScoreInfo[killerteam][0];
        int av = a + 1;
        ScoreInfo[killerteam][0] = av;

        UM.MemberHasKilled(killer, killerteam, killed, killedteam);
        UT.MemberHasKilled(killer, killerteam, killed, killedteam);
    }

    private void TeamsWeaponUse(string team, string member, string weapon)
    {
        var x = WeaponUses[team][weapon];
        int xv = x + 1;
        WeaponUses[team][weapon] = xv;


        if (weapon == "Axe")
        {
            CharacterInfo[team][member][2] = 0;
        }
        if (weapon == "Chicken")
        {
            CharacterInfo[team][member][2] = 1;
        }
        if (weapon == "Sword")
        {
            CharacterInfo[team][member][2] = 2;
        }
        if (weapon == "Shield")
        {
            CharacterInfo[team][member][2] = 3;
        }
        if (weapon == "Fish")
        {
            CharacterInfo[team][member][2] = 4;
        }
        if (weapon == "Keyboard")
        {
            CharacterInfo[team][member][2] = 5;
        }
        if (weapon == "Club")
        {
            CharacterInfo[team][member][2] = 6;
        }

        UM.TeamsWeaponUse(team, member, weapon);
        UT.TeamsWeaponUse(team, member, weapon);
    }
}
