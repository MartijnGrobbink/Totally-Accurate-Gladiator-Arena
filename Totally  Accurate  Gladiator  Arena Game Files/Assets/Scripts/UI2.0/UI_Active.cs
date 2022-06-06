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
    public UI_Teams UT;
    public UI_Members UM;

    public string activeteam;

    void Start()
    {
        //Subscribing To Events
        UI_EventsManager.current.onTeamActive += ActiveTeamSet;
    }

    private void ActiveTeamSet(string team)
    {
        activeteam = team;
        UR.TeamActive[team] = 1;

        SetNoTeam(team);

        ClearPreviousTeam(team);

        SetMembersImages(team);

        SetKillsOfOtherTeams(team);
    }

    private void SetNoTeam(string team)
    {
        if (team == "NoTeam")
        {
            var target = UR.UISectionBTargets.transform.Find("TeamUITarget");
            var start = UR.UISectionBTargets.transform.Find("TeamUIStartPos");

            UR.UISectionB.transform.position = Vector3.Lerp(start.transform.position, target.transform.position, 1);
        }

        if (team != "NoTeam")
        {
            var target = UR.UISectionBTargets.transform.Find("TeamUITarget");
            var start = UR.UISectionBTargets.transform.Find("TeamUIStartPos");

            UR.UISectionB.transform.position = Vector3.Lerp(target.transform.position, start.transform.position, 1);
        }
    }

    private void ClearPreviousTeam(string team)
    {
        if (team != "NoTeam")
        {
            var d = UR.TeamMembers["MemberA"];
            var memberA = d.transform.Find("TeamMemberKillsText");

            var e = UR.TeamMembers["Leader"];
            var leader = e.transform.Find("TeamMemberKillsText");

            var f = UR.TeamMembers["MemberB"];
            var memberB = f.transform.Find("TeamMemberKillsText");

            var g = UR.TeamMembers["MemberA"];
            var MemberA = g.transform.Find("TeamMemberDeathsText");

            var h = UR.TeamMembers["Leader"];
            var Leader = h.transform.Find("TeamMemberDeathsText");

            var i = UR.TeamMembers["MemberB"];
            var MemberB = i.transform.Find("TeamMemberDeathsText");

            memberA.GetComponent<Text>().text = TD.CharacterInfo[team]["MemberA"][0].ToString();
            MemberA.GetComponent<Text>().text = TD.CharacterInfo[team]["MemberA"][1].ToString();

            memberB.GetComponent<Text>().text = TD.CharacterInfo[team]["MemberB"][0].ToString();
            MemberB.GetComponent<Text>().text = TD.CharacterInfo[team]["MemberB"][1].ToString();

            leader.GetComponent<Text>().text = TD.CharacterInfo[team]["Leader"][0].ToString();
            Leader.GetComponent<Text>().text = TD.CharacterInfo[team]["Leader"][1].ToString();

            UT.TeamsKillsOfOtherTeams(team);

            UT.NewUsedWeaponsSorting(team);

            UM.NewTeamsWeaponUse(team);
        }
        
    }


    private void SetMembersImages(string team)
    {
        if (team != "NoTeam")
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

                var a = UR.Scores["Cavemen"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(startpos.transform.position, target.transform.position, 1);
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

                var a = UR.Scores["Vikings"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(startpos.transform.position, target.transform.position, 1);
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

                var a = UR.Scores["Knights"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(startpos.transform.position, target.transform.position, 1);
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

                var a = UR.Scores["Romans"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(startpos.transform.position, target.transform.position, 1);
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

                var a = UR.Scores["Gamers"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(startpos.transform.position, target.transform.position, 1);
            }

            
        }
        OtherTeamsOff(team);

    }

    private void OtherTeamsOff(string team)
    {
        if (team == "NoTeam")
        {
            var a = UR.Scores["Vikings"];
            var thetargets = a.transform.Find("Targets");
            var target = thetargets.transform.Find("TeamScoreTarget");
            var startpos = thetargets.transform.Find("TeamScoreStartPos");
            var tomove = a.transform.Find("ToMove");
            tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

            var b = UR.Scores["Knights"];
            var thetargetsb = b.transform.Find("Targets");
            var targetb = thetargetsb.transform.Find("TeamScoreTarget");
            var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
            var tomoveb = b.transform.Find("ToMove");
            tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

            var c = UR.Scores["Romans"];
            var thetargetsc = c.transform.Find("Targets");
            var targetc = thetargetsc.transform.Find("TeamScoreTarget");
            var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
            var tomovec = c.transform.Find("ToMove");
            tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

            var d = UR.Scores["Gamers"];
            var thetargetsd = d.transform.Find("Targets");
            var targetd = thetargetsd.transform.Find("TeamScoreTarget");
            var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
            var tomoved = d.transform.Find("ToMove");
            tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);

            var e = UR.Scores["Cavemen"];
            var thetargetse = e.transform.Find("Targets");
            var targete = thetargetse.transform.Find("TeamScoreTarget");
            var startpose = thetargetse.transform.Find("TeamScoreStartPos");
            var tomovee = e.transform.Find("ToMove");
            tomovee.transform.position = Vector3.Lerp(targete.transform.position, startpose.transform.position, 1);
        }

        if (team != "NoTeam")
        {
            if (team == "Cavemen")
            {
                var a = UR.Scores["Vikings"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

                var b = UR.Scores["Knights"];
                var thetargetsb = b.transform.Find("Targets");
                var targetb = thetargetsb.transform.Find("TeamScoreTarget");
                var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
                var tomoveb = b.transform.Find("ToMove");
                tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

                var c = UR.Scores["Romans"];
                var thetargetsc = c.transform.Find("Targets");
                var targetc = thetargetsc.transform.Find("TeamScoreTarget");
                var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
                var tomovec = c.transform.Find("ToMove");
                tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

                var d = UR.Scores["Gamers"];
                var thetargetsd = d.transform.Find("Targets");
                var targetd = thetargetsd.transform.Find("TeamScoreTarget");
                var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
                var tomoved = d.transform.Find("ToMove");
                tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);
            }

            if (team == "Knights")
            {
                var a = UR.Scores["Vikings"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

                var b = UR.Scores["Cavemen"];
                var thetargetsb = b.transform.Find("Targets");
                var targetb = thetargetsb.transform.Find("TeamScoreTarget");
                var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
                var tomoveb = b.transform.Find("ToMove");
                tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

                var c = UR.Scores["Romans"];
                var thetargetsc = c.transform.Find("Targets");
                var targetc = thetargetsc.transform.Find("TeamScoreTarget");
                var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
                var tomovec = c.transform.Find("ToMove");
                tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

                var d = UR.Scores["Gamers"];
                var thetargetsd = d.transform.Find("Targets");
                var targetd = thetargetsd.transform.Find("TeamScoreTarget");
                var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
                var tomoved = d.transform.Find("ToMove");
                tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);
            }

            if (team == "Gamers")
            {
                var a = UR.Scores["Vikings"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

                var b = UR.Scores["Cavemen"];
                var thetargetsb = b.transform.Find("Targets");
                var targetb = thetargetsb.transform.Find("TeamScoreTarget");
                var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
                var tomoveb = b.transform.Find("ToMove");
                tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

                var c = UR.Scores["Romans"];
                var thetargetsc = c.transform.Find("Targets");
                var targetc = thetargetsc.transform.Find("TeamScoreTarget");
                var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
                var tomovec = c.transform.Find("ToMove");
                tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

                var d = UR.Scores["Knights"];
                var thetargetsd = d.transform.Find("Targets");
                var targetd = thetargetsd.transform.Find("TeamScoreTarget");
                var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
                var tomoved = d.transform.Find("ToMove");
                tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);
            }

            if (team == "Romans")
            {
                var a = UR.Scores["Vikings"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

                var b = UR.Scores["Cavemen"];
                var thetargetsb = b.transform.Find("Targets");
                var targetb = thetargetsb.transform.Find("TeamScoreTarget");
                var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
                var tomoveb = b.transform.Find("ToMove");
                tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

                var c = UR.Scores["Gamers"];
                var thetargetsc = c.transform.Find("Targets");
                var targetc = thetargetsc.transform.Find("TeamScoreTarget");
                var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
                var tomovec = c.transform.Find("ToMove");
                tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

                var d = UR.Scores["Knights"];
                var thetargetsd = d.transform.Find("Targets");
                var targetd = thetargetsd.transform.Find("TeamScoreTarget");
                var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
                var tomoved = d.transform.Find("ToMove");
                tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);
            }

            if (team == "Vikings")
            {
                var a = UR.Scores["Romans"];
                var thetargets = a.transform.Find("Targets");
                var target = thetargets.transform.Find("TeamScoreTarget");
                var startpos = thetargets.transform.Find("TeamScoreStartPos");
                var tomove = a.transform.Find("ToMove");
                tomove.transform.position = Vector3.Lerp(target.transform.position, startpos.transform.position, 1);

                var b = UR.Scores["Cavemen"];
                var thetargetsb = b.transform.Find("Targets");
                var targetb = thetargetsb.transform.Find("TeamScoreTarget");
                var startposb = thetargetsb.transform.Find("TeamScoreStartPos");
                var tomoveb = b.transform.Find("ToMove");
                tomoveb.transform.position = Vector3.Lerp(targetb.transform.position, startposb.transform.position, 1);

                var c = UR.Scores["Gamers"];
                var thetargetsc = c.transform.Find("Targets");
                var targetc = thetargetsc.transform.Find("TeamScoreTarget");
                var startposc = thetargetsc.transform.Find("TeamScoreStartPos");
                var tomovec = c.transform.Find("ToMove");
                tomovec.transform.position = Vector3.Lerp(targetc.transform.position, startposc.transform.position, 1);

                var d = UR.Scores["Knights"];
                var thetargetsd = d.transform.Find("Targets");
                var targetd = thetargetsd.transform.Find("TeamScoreTarget");
                var startposd = thetargetsd.transform.Find("TeamScoreStartPos");
                var tomoved = d.transform.Find("ToMove");
                tomoved.transform.position = Vector3.Lerp(targetd.transform.position, startposd.transform.position, 1);
            }
        }
        

    }

    private void SetKillsOfOtherTeams(string team)
    {
        Dictionary<string, int> active = new Dictionary<string, int>();
        if (team != "NoTeam")
        {
            
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
        }

        UR.TeamActive.Clear();

        foreach (KeyValuePair<string, int> item in active)
        {
            UR.TeamActive.Add(item.Key, item.Value);
        }
    }

}
