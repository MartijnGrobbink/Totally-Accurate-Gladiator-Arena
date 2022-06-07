using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Refs : MonoBehaviour
{
    //Team/Member UI Section
    public GameObject UISectionB;
    public GameObject UISectionBTargets;

    public Dictionary<string, int> TeamActive = new Dictionary<string, int>();

    //Kill Feed UI
    public GameObject KillLogPrefab;
    public GameObject KillLogLayout;

    public Dictionary<string, GameObject> KillLogs = new Dictionary<string, GameObject>();

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
    public GameObject ScorePrefab;
    public GameObject ScoreLayout;

    public Dictionary<string, GameObject> Scores = new Dictionary<string, GameObject>();

    //StatueUI
    public GameObject StatuePrefab;
    public GameObject StatueLayout;

    public Dictionary<string, GameObject> Statues = new Dictionary<string, GameObject>();

    void Start()
    {
        TeamActive.Add("NoTeam", 0);
        TeamActive.Add("Cavemen", 0);
        TeamActive.Add("Gamers", 0);
        TeamActive.Add("Knights", 0);
        TeamActive.Add("Vikings", 0);
        TeamActive.Add("Romans", 0);


        var target = UISectionBTargets.transform.Find("TeamUITarget");
        var start = UISectionBTargets.transform.Find("TeamUIStartPos");

        UISectionB.transform.position = Vector3.Lerp(start.transform.position, target.transform.position, 1);
    }
}
