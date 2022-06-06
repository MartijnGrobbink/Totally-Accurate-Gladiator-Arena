using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Score : MonoBehaviour
{
    public UI_Refs UR;
    public Teams_Data TD;
    public Weapon_Assets WA;
    public Team_Assets TA;

    public int CapturedPoints;
    public int KilledPoints;

    void Start()
    {
        
    }

    public void MemberHasKilled(string killerteam)
    {
        AddKilledPoints(killerteam);
    }

    public void TeamsStatueCaptures(string team)
    {
        AddCapturedPoints(team);
    }

    private void AddCapturedPoints(string team)
    {
        if (team == "Cavemen")
        {
            var a = UR.Scores["Cavemen"];
            var theteama = a.transform.Find("ToMove");
            var teama = theteama.transform.Find("TeamTextPoints");
            var teamscore = teama.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + CapturedPoints;
            teama.GetComponent<Text>().text = score.ToString();
        }

        if (team == "Vikings")
        {
            var b = UR.Scores["Vikings"];
            var theteamb = b.transform.Find("ToMove");
            var teamb = theteamb.transform.Find("TeamTextPoints");
            var teamscore = teamb.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + CapturedPoints;
            teamb.GetComponent<Text>().text = score.ToString();
        }

        if (team == "Romans")
        {
            var c = UR.Scores["Romans"];
            var theteamc = c.transform.Find("ToMove");
            var teamc = theteamc.transform.Find("TeamTextPoints");
            var teamscore = teamc.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + CapturedPoints;
            teamc.GetComponent<Text>().text = score.ToString();
        }

        if (team == "Knights")
        {
            var d = UR.Scores["Knights"];
            var theteamd = d.transform.Find("ToMove");
            var teamd = theteamd.transform.Find("TeamTextPoints");
            var teamscore = teamd.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + CapturedPoints;
            teamd.GetComponent<Text>().text = score.ToString();
        }

        if (team == "Gamers")
        {
            var e = UR.Scores["Gamers"];
            var theteame = e.transform.Find("ToMove");
            var teame = theteame.transform.Find("TeamTextPoints");
            var teamscore = teame.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + CapturedPoints;
            teame.GetComponent<Text>().text = score.ToString();
        }
    }

    private void AddKilledPoints(string killerteam)
    {
        if (killerteam == "Cavemen")
        {
            var a = UR.Scores["Cavemen"];
            var theteama = a.transform.Find("ToMove");
            var teama = theteama.transform.Find("TeamTextPoints");
            var teamscore = teama.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + KilledPoints;
            teama.GetComponent<Text>().text = score.ToString();
        }

        if (killerteam == "Vikings")
        {
            var b = UR.Scores["Vikings"];
            var theteamb = b.transform.Find("ToMove");
            var teamb = theteamb.transform.Find("TeamTextPoints");
            var teamscore = teamb.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + KilledPoints;
            teamb.GetComponent<Text>().text = score.ToString();
        }

        if (killerteam == "Romans")
        {
            var c = UR.Scores["Romans"];
            var theteamc = c.transform.Find("ToMove");
            var teamc = theteamc.transform.Find("TeamTextPoints");
            var teamscore = teamc.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + KilledPoints;
            teamc.GetComponent<Text>().text = score.ToString();
        }

        if (killerteam == "Knights")
        {
            var d = UR.Scores["Knights"];
            var theteamd = d.transform.Find("ToMove");
            var teamd = theteamd.transform.Find("TeamTextPoints");
            var teamscore = teamd.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + KilledPoints;
            teamd.GetComponent<Text>().text = score.ToString();
        }

        if (killerteam == "Gamers")
        {
            var e = UR.Scores["Gamers"];
            var theteame = e.transform.Find("ToMove");
            var teame = theteame.transform.Find("TeamTextPoints");
            var teamscore = teame.GetComponent<Text>().text;
            var score = int.Parse(teamscore) + KilledPoints;
            teame.GetComponent<Text>().text = score.ToString();
        }
    }

    public void SetTeamLogos()
    {
        var a = UR.Scores["Cavemen"];
        var teama = a.transform.Find("ToMove");
        var thteama = teama.transform.Find("TeamImageLogo");

        var b = UR.Scores["Vikings"];
        var teamb = b.transform.Find("ToMove");
        var thteamb = teamb.transform.Find("TeamImageLogo");

        var c = UR.Scores["Romans"];
        var teamc = c.transform.Find("ToMove");
        var thteamc = teamc.transform.Find("TeamImageLogo");

        var d = UR.Scores["Knights"];
        var teamd = d.transform.Find("ToMove");
        var thteamd = teamd.transform.Find("TeamImageLogo");

        var e = UR.Scores["Gamers"];
        var teame = e.transform.Find("ToMove");
        var thteame = teame.transform.Find("TeamImageLogo");

        foreach (Sprite sprite in TA.CharactersImages)
        {
            if (sprite.name == "cavemanleader")
            {
                thteama.GetComponent<Image>().sprite = sprite;
            }

            if (sprite.name == "vikingleader")
            {
                thteamb.GetComponent<Image>().sprite = sprite;
            }

            if (sprite.name == "romanleader")
            {
                thteamc.GetComponent<Image>().sprite = sprite;
            }

            if (sprite.name == "knightleader")
            {
                thteamd.GetComponent<Image>().sprite = sprite;
            }

            if (sprite.name == "gamerleader")
            {
                thteame.GetComponent<Image>().sprite = sprite;
            }
        }
    }
}
