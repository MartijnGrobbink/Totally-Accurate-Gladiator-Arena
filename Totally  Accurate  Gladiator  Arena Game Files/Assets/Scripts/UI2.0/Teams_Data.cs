using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teams_Data : MonoBehaviour
{
    public UI_Members UM;
    public UI_Teams UT;
    public UI_KillFeed UF;
    public UI_Score US;
    public UI_Statue UST;

    public Dictionary<string, Dictionary<string, int>> WeaponUses = new Dictionary<string, Dictionary<string, int>>();
   
    public Dictionary<string, Dictionary<string, int>> OtherTeamsKilled = new Dictionary<string, Dictionary<string, int>>();

    public Dictionary<string, Dictionary<string, List<int>>> CharacterInfo = new Dictionary<string, Dictionary<string, List<int>>>();

    public static Dictionary<string, List<int>> ScoreInfo = new Dictionary<string, List<int>>();

    public string StatueStatus;
    // NoTeam for contested

    void Start()
    {
        //Clearing Dics
        ScoreInfo.Clear();
        //Subscribing To Events
        Teams_EventManager.current.onHasKilled += MemberHasKilled;
        Teams_EventManager.current.onWeaponUsed += TeamsWeaponUse;
        Teams_EventManager.current.onStatueCaptures += TeamsStatueCaptures;
        Teams_EventManager.current.onStatueStatus += TeamsStatueStatus;
        //Setting Teams Dictionaries
        Gamers();
        Cavemen();
        Romans();
        Knights();
        Vikings();
    }

    private void TeamsStatueStatus(string team)
    {
        StatueStatus = team;

        UST.TeamsStatueStatus(team);
    }

    private void TeamsStatueCaptures(string team) 
    {
        var x = ScoreInfo[team][1];
        int xv = x + 1;
        ScoreInfo[team][1] = xv;

        US.TeamsStatueCaptures(team);
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
        UF.MemberHasKilled(killer, killerteam, weapon, killed, killedteam);
        US.MemberHasKilled(killerteam);
    }

    private void TeamsWeaponUse(string team, string member, string weapon)
    {
        var x = WeaponUses[team][weapon];
        int xv = x + 1;
        WeaponUses[team][weapon] = xv;

        if (weapon == "NoWeapon")
        {
            CharacterInfo[team][member][2] = 0;
        }
        if (weapon == "Axe")
        {
            CharacterInfo[team][member][2] = 1;
        }
        if (weapon == "Chicken")
        {
            CharacterInfo[team][member][2] = 2;
        }
        if (weapon == "Sword")
        {
            CharacterInfo[team][member][2] = 3;
        }
        if (weapon == "Shield")
        {
            CharacterInfo[team][member][2] = 4;
        }
        if (weapon == "Fish")
        {
            CharacterInfo[team][member][2] = 5;
        }
        if (weapon == "Keyboard")
        {
            CharacterInfo[team][member][2] = 6;
        }
        if (weapon == "Club")
        {
            CharacterInfo[team][member][2] = 7;
        }

        UM.TeamsWeaponUse(team, member);
        UT.TeamsWeaponUse(team, member, weapon);
    }

    private void Vikings()
    {
        //
        //--------------------------------------------------------Vikings------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = no wepaon, 1 = axe, 2 = chicken, 3 = sword, 4 = shield, 5 = fish, 6 = keyboard, 7 = club)
        List<int> CharacterDataList40 = new List<int>();
        List<int> CharacterDataList41 = new List<int>();
        List<int> CharacterDataList42 = new List<int>();
        Dictionary<string, List<int>> CharacterData40 = new Dictionary<string, List<int>>();
        CharacterDataList40.Add(0);
        CharacterDataList40.Add(0);
        CharacterDataList40.Add(0);
        CharacterData40.Add("MemberA", CharacterDataList40);
        CharacterDataList41.Add(0);
        CharacterDataList41.Add(0);
        CharacterDataList41.Add(0);
        CharacterData40.Add("Leader", CharacterDataList41);
        CharacterDataList42.Add(0);
        CharacterDataList42.Add(0);
        CharacterDataList42.Add(0);
        CharacterData40.Add("MemberB", CharacterDataList42);
        CharacterInfo.Add("Vikings", CharacterData40);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed40 = new Dictionary<string, int>();
        WeaponsUsed40.Add("NoWeapon", 0);
        WeaponsUsed40.Add("Axe", 0);
        WeaponsUsed40.Add("Chicken", 0);
        WeaponsUsed40.Add("Sword", 0);
        WeaponsUsed40.Add("Shield", 0);
        WeaponsUsed40.Add("Fish", 0);
        WeaponsUsed40.Add("Keyboard", 0);
        WeaponsUsed40.Add("Club", 0);
        WeaponUses.Add("Vikings", WeaponsUsed40);
        //Setting OtherTeamsKilled
        Dictionary<string, int> TeamsKilled40 = new Dictionary<string, int>();
        TeamsKilled40.Add("Cavemen", 0);
        TeamsKilled40.Add("Romans", 0);
        TeamsKilled40.Add("Gamers", 0);
        TeamsKilled40.Add("Knights", 0);
        OtherTeamsKilled.Add("Vikings", TeamsKilled40);
        //Setting ScoreInfo - List item 0 is kills total, List item 1 is captures total
        List<int> ScoreData40 = new List<int>();
        ScoreData40.Add(0);
        ScoreData40.Add(0);
        ScoreInfo.Add("Vikings", ScoreData40);
    }

    private void Gamers()
    {
        //
        //--------------------------------------------------------Gamers------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = no wepaon, 1 = axe, 2 = chicken, 3 = sword, 4 = shield, 5 = fish, 6 = keyboard, 7 = club)
        List<int> CharacterDataList10 = new List<int>();
        List<int> CharacterDataList11 = new List<int>();
        List<int> CharacterDataList12 = new List<int>();
        Dictionary<string, List<int>> CharacterData10 = new Dictionary<string, List<int>>();
        CharacterDataList10.Add(0);
        CharacterDataList10.Add(0);
        CharacterDataList10.Add(0);
        CharacterData10.Add("MemberA", CharacterDataList10);
        CharacterDataList11.Add(0);
        CharacterDataList11.Add(0);
        CharacterDataList11.Add(0);
        CharacterData10.Add("Leader", CharacterDataList11);
        CharacterDataList12.Add(0);
        CharacterDataList12.Add(0);
        CharacterDataList12.Add(0);
        CharacterData10.Add("MemberB", CharacterDataList12);
        CharacterInfo.Add("Gamers", CharacterData10);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed10 = new Dictionary<string, int>();
        WeaponsUsed10.Add("NoWeapon", 0);
        WeaponsUsed10.Add("Axe", 0);
        WeaponsUsed10.Add("Chicken", 0);
        WeaponsUsed10.Add("Sword", 0);
        WeaponsUsed10.Add("Shield", 0);
        WeaponsUsed10.Add("Fish", 0);
        WeaponsUsed10.Add("Keyboard", 0);
        WeaponsUsed10.Add("Club", 0);
        WeaponUses.Add("Gamers", WeaponsUsed10);
        //Setting OtherTeamsKilled
        Dictionary<string, int> TeamsKilled10 = new Dictionary<string, int>();
        TeamsKilled10.Add("Cavemen", 0);
        TeamsKilled10.Add("Vikings", 0);
        TeamsKilled10.Add("Knights", 0);
        TeamsKilled10.Add("Romans", 0);
        OtherTeamsKilled.Add("Gamers", TeamsKilled10);
        //Setting ScoreInfo - List item 0 is kills total, List item 1 is captures total
        List<int> ScoreData10 = new List<int>();
        ScoreData10.Add(0);
        ScoreData10.Add(0);
        ScoreInfo.Add("Gamers", ScoreData10);
    }

    private void Knights()
    {
        //
        //--------------------------------------------------------Knights------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = no wepaon, 1 = axe, 2 = chicken, 3 = sword, 4 = shield, 5 = fish, 6 = keyboard, 7 = club)
        List<int> CharacterDataList20 = new List<int>();
        List<int> CharacterDataList21 = new List<int>();
        List<int> CharacterDataList22 = new List<int>();
        Dictionary<string, List<int>> CharacterData20 = new Dictionary<string, List<int>>();
        CharacterDataList20.Add(0);
        CharacterDataList20.Add(0);
        CharacterDataList20.Add(0);
        CharacterData20.Add("MemberA", CharacterDataList20);
        CharacterDataList21.Add(0);
        CharacterDataList21.Add(0);
        CharacterDataList21.Add(0);
        CharacterData20.Add("Leader", CharacterDataList21);
        CharacterDataList22.Add(0);
        CharacterDataList22.Add(0);
        CharacterDataList22.Add(0);
        CharacterData20.Add("MemberB", CharacterDataList22);
        CharacterInfo.Add("Knights", CharacterData20);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed20 = new Dictionary<string, int>();
        WeaponsUsed20.Add("NoWeapon", 0);
        WeaponsUsed20.Add("Axe", 0);
        WeaponsUsed20.Add("Chicken", 0);
        WeaponsUsed20.Add("Sword", 0);
        WeaponsUsed20.Add("Shield", 0);
        WeaponsUsed20.Add("Fish", 0);
        WeaponsUsed20.Add("Keyboard", 0);
        WeaponsUsed20.Add("Club", 0);
        WeaponUses.Add("Knights", WeaponsUsed20);
        //Setting OtherTeamsKilled
        Dictionary<string, int> TeamsKilled20 = new Dictionary<string, int>();
        TeamsKilled20.Add("Cavemen", 0);
        TeamsKilled20.Add("Vikings", 0);
        TeamsKilled20.Add("Gamers", 0);
        TeamsKilled20.Add("Romans", 0);
        OtherTeamsKilled.Add("Knights", TeamsKilled20);
        //Setting ScoreInfo - List item 0 is kills total, List item 1 is captures total
        List<int> ScoreData20 = new List<int>();
        ScoreData20.Add(0);
        ScoreData20.Add(0);
        ScoreInfo.Add("Knights", ScoreData20);
    }

    private void Romans()
    {
        //
        //--------------------------------------------------------Romans------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = no wepaon, 1 = axe, 2 = chicken, 3 = sword, 4 = shield, 5 = fish, 6 = keyboard, 7 = club)
        List<int> CharacterDataList30 = new List<int>();
        List<int> CharacterDataList31 = new List<int>();
        List<int> CharacterDataList32 = new List<int>();
        Dictionary<string, List<int>> CharacterData30 = new Dictionary<string, List<int>>();
        CharacterDataList30.Add(0);
        CharacterDataList30.Add(0);
        CharacterDataList30.Add(0);
        CharacterData30.Add("MemberA", CharacterDataList30);
        CharacterDataList31.Add(0);
        CharacterDataList31.Add(0);
        CharacterDataList31.Add(0);
        CharacterData30.Add("Leader", CharacterDataList31);
        CharacterDataList32.Add(0);
        CharacterDataList32.Add(0);
        CharacterDataList32.Add(0);
        CharacterData30.Add("MemberB", CharacterDataList32);
        CharacterInfo.Add("Romans", CharacterData30);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed30 = new Dictionary<string, int>();
        WeaponsUsed30.Add("NoWeapon", 0);
        WeaponsUsed30.Add("Axe", 0);
        WeaponsUsed30.Add("Chicken", 0);
        WeaponsUsed30.Add("Sword", 0);
        WeaponsUsed30.Add("Shield", 0);
        WeaponsUsed30.Add("Fish", 0);
        WeaponsUsed30.Add("Keyboard", 0);
        WeaponsUsed30.Add("Club", 0);
        WeaponUses.Add("Romans", WeaponsUsed30);
        //Setting OtherTeamsKilled
        Dictionary<string, int> TeamsKilled30 = new Dictionary<string, int>();
        TeamsKilled30.Add("Cavemen", 0);
        TeamsKilled30.Add("Vikings", 0);
        TeamsKilled30.Add("Gamers", 0);
        TeamsKilled30.Add("Knights", 0);
        OtherTeamsKilled.Add("Romans", TeamsKilled30);
        //Setting ScoreInfo - List item 0 is kills total, List item 1 is captures total
        List<int> ScoreData30 = new List<int>();
        ScoreData30.Add(0);
        ScoreData30.Add(0);
        ScoreInfo.Add("Romans", ScoreData30);
    }

    private void Cavemen()
    {
        //--------------------------------------------------------Cavemen------------------------------------------------------------------------
        //Setting CharacterInfo - List item 0 is kills, List item 1 is deaths, list item 2 is active weapon (for active weapon part 0 = no wepaon, 1 = axe, 2 = chicken, 3 = sword, 4 = shield, 5 = fish, 6 = keyboard, 7 = club)
        List<int> CharacterDataList00 = new List<int>();
        List<int> CharacterDataList01 = new List<int>();
        List<int> CharacterDataList02 = new List<int>();
        Dictionary<string, List<int>> CharacterData00 = new Dictionary<string, List<int>>();
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterDataList00.Add(0);
        CharacterData00.Add("MemberA", CharacterDataList00);
        CharacterDataList01.Add(0);
        CharacterDataList01.Add(0);
        CharacterDataList01.Add(0);
        CharacterData00.Add("Leader", CharacterDataList01);
        CharacterDataList02.Add(0);
        CharacterDataList02.Add(0);
        CharacterDataList02.Add(0);
        CharacterData00.Add("MemberB", CharacterDataList02);
        CharacterInfo.Add("Cavemen", CharacterData00);
        //Setting WeaponUses
        Dictionary<string, int> WeaponsUsed00 = new Dictionary<string, int>();
        WeaponsUsed00.Add("NoWeapon", 0);
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
    }
}
