using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Statue : MonoBehaviour
{
    public UI_Refs UR;
    public Teams_Data TD;
    public Team_Assets TA;
    public Statue_Assets SA;

    public int CapturedPoints;
    public int KilledPoints;

    void Start()
    {
        
    }

    public void TeamsStatueStatus(string team)
    {
        CheckActiveTeam(team);
    }

    private void CheckActiveTeam(string team)
    {
        if (team == "NoTeam")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "NoTeamStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 0f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Contested")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "ContestedStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 0f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Cavemen")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "CavemanStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "cavemanleader")
                {
                    statuecapa.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 1f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Gamers")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "GamerStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "gamerleader")
                {
                    statuecapa.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 1f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Vikings")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "VikingStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "vikingleader")
                {
                    statuecapa.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 1f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Knights")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "KnightStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "knightleader")
                {
                    statuecapa.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 1f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }

        if (team == "Romans")
        {
            var a = UR.Statues["StatueA"];
            var statuea = a.transform.Find("StatueStatus");
            var statuecapa = a.transform.Find("TeamImageCap");

            foreach (Sprite sprite in SA.StatueImages)
            {
                if (sprite.name == "RomanStatue")
                {
                    statuea.GetComponent<Image>().sprite = sprite;
                }
            }

            foreach (Sprite sprite in TA.CharactersImages)
            {
                if (sprite.name == "romanleader")
                {
                    statuecapa.GetComponent<Image>().sprite = sprite;
                }
            }

            var tempColor = statuecapa.GetComponent<Image>().color;
            tempColor.a = 1f;
            statuecapa.GetComponent<Image>().color = tempColor;
        }
    }

    public void SetStatueLogo()
    {
        var a = UR.Statues["StatueA"];
        var statuea = a.transform.Find("StatueStatus");
        foreach (Sprite sprite in SA.StatueImages)
        {
            if (sprite.name == "NoTeamStatue")
            {
                statuea.GetComponent<Image>().sprite = sprite;
            }
        }
    }
}
