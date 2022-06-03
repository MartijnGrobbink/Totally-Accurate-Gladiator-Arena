using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Refs : MonoBehaviour
{
    //Team/Member UI Section
    public GameObject UISectionB;

    public Dictionary<string, int> TeamActive = new Dictionary<string, int>();

    //Kill Feed UI
    public Text UIKiller;
    public Image UIWeapon;
    public Text UIDead;

    //Team UI
    public Text UITeamNameText;

    public GameObject TeamsKilledInfoPrefab;
    public GameObject TeamsKilledInfoLayout;

    public GameObject WeaponsUsedPrefab;
    public GameObject WeaponsUsedLayout;

    public Dictionary<string, GameObject> WeaponsUsed = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> TeamsKilled = new Dictionary<string, GameObject>();

    //Members UI
    public GameObject MembersPrefab;
    public GameObject MembersLayout;

    public Dictionary<string, GameObject> TeamMembers = new Dictionary<string, GameObject>();

    //ScoreUI
    public GameObject UITeam;
    public GameObject UITeamTarget;
    public GameObject UITeamStartPos;

    public Text UITeamTextPoints;

    //StatueUI
    public Image UIStatueStatus;
    public Image UITeamImageCap;

    void Start()
    {
        TeamActive.Add("Cavemen", 0);
        TeamActive.Add("Gamers", 0);
        TeamActive.Add("Knights", 0);
        TeamActive.Add("Vikings", 0);
        TeamActive.Add("Romans", 0);
    }
}
