using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Active : MonoBehaviour
{
    public UI_Refs UR;
    public Teams_Data TD;
    public Team_Assets TA;

    void Start()
    {
        //Subscribing To Events
        UI_EventsManager.current.onTeamActive += ActiveTeamSet;
    }
    
    

    
    private void ActiveTeamSet(string team)
    {
        SetMembersImages(team);

        SetKillsOfOtherTeams(team);
    }

    private void SetMembersImages(string team)
    {
        

        var d = UR.TeamMembers["MemberA"];
        var memberA = d.transform.Find("TeamMemberImage");

        var e = UR.TeamMembers["Leader"];
        var leader = e.transform.Find("TeamMemberImage");

        var f = UR.TeamMembers["MemberB"];
        var memberB = f.transform.Find("TeamMemberImage");

        var g = UR.TeamMembers["MemberA"];
        var MemberA = g.transform.Find("TeamMemberNameText");

        var h = UR.TeamMembers["Leader"];
        var Leader = h.transform.Find("TeamMemberNameText");

        var i = UR.TeamMembers["MemberB"];
        var MemberB = i.transform.Find("TeamMemberNameText");

        MemberA.GetComponent<Text>().text = "John";
        MemberB.GetComponent<Text>().text = "Jim";
        Leader.GetComponent<Text>().text = "Jimmy";

        if (team == "Cavemen")
        {
            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "cavemanfollower")
                {
                    memberA.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "cavemanfollower1")
                {
                    memberB.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "cavemanleader")
                {
                    leader.GetComponent<Image>().sprite = sprite;
                }
            }
        }

        if (team == "Vikings")
        {
            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "vikingfollower")
                {
                    memberA.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "vikingfollower1")
                {
                    memberB.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "vikingleader")
                {
                    leader.GetComponent<Image>().sprite = sprite;
                }
            }
        }

        if (team == "Knights")
        {
            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "knightfollower")
                {
                    memberA.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "knightfollower")
                {
                    memberB.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "knightleader")
                {
                    leader.GetComponent<Image>().sprite = sprite;
                }
            }
        }

        if (team == "Romans")
        {
            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "romanfollower")
                {
                    memberA.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "romanfollower1")
                {
                    memberB.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "romanleader")
                {
                    leader.GetComponent<Image>().sprite = sprite;
                }
            }
        }

        if (team == "Gamers")
        {
            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "gamerfollower")
                {
                    memberA.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "gamerfollower1")
                {
                    memberB.GetComponent<Image>().sprite = sprite;
                }

                if (sprite.name == "gamerleader")
                {
                    leader.GetComponent<Image>().sprite = sprite;
                }
            }
        }
    }

    private void SetKillsOfOtherTeams(string team)
    {
        Dictionary<string, int> active = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> item in UR.TeamActive)
        {
            if (item.Key == team)
            {
                active.Add(item.Key, 1);
                UR.UITeamNameText.text = team;

                var y = UR.TeamsKilled["TeamA"];
                var teamA = y.transform.Find("TeamKilledText");

                var x = UR.TeamsKilled["TeamB"];
                var teamB = x.transform.Find("TeamKilledText");

                var z = UR.TeamsKilled["TeamC"];
                var teamC = z.transform.Find("TeamKilledText");

                var a = UR.TeamsKilled["TeamD"];
                var teamD = a.transform.Find("TeamKilledText");

                int g = 0;

                foreach (KeyValuePair<string, int> pair in TD.OtherTeamsKilled[team])
                {
                    g = g + 1;

                    if (g == 1)
                    {
                        teamA.GetComponent<Text>().text = pair.Key + " killed";
                    }

                    if (g == 2)
                    {
                        teamB.GetComponent<Text>().text = pair.Key + " killed";
                    }

                    if (g == 3)
                    {
                        teamC.GetComponent<Text>().text = pair.Key + " killed";
                    }

                    if (g == 4)
                    {
                        teamD.GetComponent<Text>().text = pair.Key + " killed";
                    }
                }
            }

            if (item.Key != team)
            {
                active.Add(item.Key, 0);
            }
        }

        UR.TeamActive.Clear();

        foreach (KeyValuePair<string, int> item in active)
        {
            UR.TeamActive.Add(item.Key, item.Value);
        }
    }

}
