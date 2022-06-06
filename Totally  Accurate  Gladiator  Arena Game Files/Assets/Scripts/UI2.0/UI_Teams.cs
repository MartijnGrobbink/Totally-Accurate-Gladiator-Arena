using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Teams : MonoBehaviour
{
    public UI_Refs UR;
    public UI_Active UA;
    public Teams_Data TD;
    public Weapon_Assets WA;


    public void MemberHasKilled(string killer, string killerteam, string killed, string killedteam)
    {
        //Set Teams kills of other teams
        TeamsKillsOfOtherTeams(killerteam);
    }

    public void TeamsWeaponUse(string team, string member, string weapon)
    {
        //Set Used Weapon For Team
        UsedWeaponsSorting(team);
    }

    public void TeamsKillsOfOtherTeams(string killerteam)
    {
        var y = UR.TeamsKilled["TeamA"];
        var teamA = y.transform.Find("TeamKillsText");

        var x = UR.TeamsKilled["TeamB"];
        var teamB = x.transform.Find("TeamKillsText");

        var z = UR.TeamsKilled["TeamC"];
        var teamC = z.transform.Find("TeamKillsText");

        var a = UR.TeamsKilled["TeamD"];
        var teamD = a.transform.Find("TeamKillsText");

        int g = 0;
        if (UA.activeteam == killerteam)
        {
            foreach (KeyValuePair<string, int> pair in TD.OtherTeamsKilled[killerteam])
            {
                g = g + 1;

                if (g == 1)
                {
                    teamA.GetComponent<Text>().text = TD.OtherTeamsKilled[killerteam][pair.Key].ToString();
                }

                if (g == 2)
                {
                    teamB.GetComponent<Text>().text = TD.OtherTeamsKilled[killerteam][pair.Key].ToString();
                }

                if (g == 3)
                {
                    teamC.GetComponent<Text>().text = TD.OtherTeamsKilled[killerteam][pair.Key].ToString();
                }

                if (g == 4)
                {
                    teamD.GetComponent<Text>().text = TD.OtherTeamsKilled[killerteam][pair.Key].ToString();
                }
            }
        }
        
    }

    public void UsedWeaponsSorting(string team)
    {
        foreach (KeyValuePair<string, int> paira in UR.TeamActive)
        {
            if (paira.Value == 1)
            {
                if (paira.Key == team)
                {
                    var sorted = TD.WeaponUses[team].OrderByDescending(key => key.Value);
                    var l = 0;
                    var f = UR.WeaponsUsed["WeaponA"];
                    var weaponA = f.transform.Find("UsedWeapon");

                    var z = UR.WeaponsUsed["WeaponB"];
                    var weaponB = z.transform.Find("UsedWeapon");

                    var a = UR.WeaponsUsed["WeaponC"];
                    var weaponC = a.transform.Find("UsedWeapon");

                    foreach (KeyValuePair<string, int> pair in sorted)
                    {
                        l = l + 1;

                        if (l == 1)
                        {
                            if (pair.Value > 0)
                            {
                                var tempColor = weaponA.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                weaponA.GetComponent<Image>().color = tempColor;

                                if (pair.Key == "Axe")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "axe")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }

                                }
                                if (pair.Key == "Chicken")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "chicken")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Sword")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "sword")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Shield")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "shield")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Fish")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "fish")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Keyboard")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "keyboard")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Club")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "club")
                                        {
                                            weaponA.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var tempColor = weaponA.GetComponent<Image>().color;
                                tempColor.a = 0f;
                                weaponA.GetComponent<Image>().color = tempColor;
                            }
                        }

                        if (l == 2)
                        {
                            if (pair.Value > 0)
                            {
                                var tempColor = weaponB.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                weaponB.GetComponent<Image>().color = tempColor;

                                if (pair.Key == "Axe")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "axe")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }

                                }
                                if (pair.Key == "Chicken")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "chicken")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Sword")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "sword")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Shield")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "shield")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Fish")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "fish")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Keyboard")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "keyboard")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Club")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "club")
                                        {
                                            weaponB.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var tempColor = weaponB.GetComponent<Image>().color;
                                tempColor.a = 0f;
                                weaponB.GetComponent<Image>().color = tempColor;
                            }
                        }

                        if (l == 3)
                        {
                            if (pair.Value > 0)
                            {
                                var tempColor = weaponC.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                weaponC.GetComponent<Image>().color = tempColor;

                                if (pair.Key == "Axe")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "axe")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }

                                }
                                if (pair.Key == "Chicken")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "chicken")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Sword")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "sword")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Shield")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "shield")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Fish")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "fish")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Keyboard")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "keyboard")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                                if (pair.Key == "Club")
                                {
                                    foreach (Sprite sprite in WA.WeaponImages)
                                    {
                                        if (sprite.name == "club")
                                        {
                                            weaponC.GetComponent<Image>().sprite = sprite;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var tempColor = weaponC.GetComponent<Image>().color;
                                tempColor.a = 0f;
                                weaponC.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                }
            }
        }
    }

    public void NewUsedWeaponsSorting(string team)
    {
        var sorted = TD.WeaponUses[team].OrderByDescending(key => key.Value);
        var l = 0;
        var f = UR.WeaponsUsed["WeaponA"];
        var weaponA = f.transform.Find("UsedWeapon");

        var z = UR.WeaponsUsed["WeaponB"];
        var weaponB = z.transform.Find("UsedWeapon");

        var a = UR.WeaponsUsed["WeaponC"];
        var weaponC = a.transform.Find("UsedWeapon");

        foreach (KeyValuePair<string, int> pair in sorted)
        {
            l = l + 1;

            if (l == 1)
            {
                if (pair.Value > 0)
                {
                    var tempColor = weaponA.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    weaponA.GetComponent<Image>().color = tempColor;

                    if (pair.Key == "Axe")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "axe")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }

                    }
                    if (pair.Key == "Chicken")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "chicken")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Sword")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "sword")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Shield")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "shield")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Fish")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "fish")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Keyboard")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "keyboard")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Club")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "club")
                            {
                                weaponA.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                }
                else
                {
                    var tempColor = weaponA.GetComponent<Image>().color;
                    tempColor.a = 0f;
                    weaponA.GetComponent<Image>().color = tempColor;
                }
            }

            if (l == 2)
            {
                if (pair.Value > 0)
                {
                    var tempColor = weaponB.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    weaponB.GetComponent<Image>().color = tempColor;

                    if (pair.Key == "Axe")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "axe")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }

                    }
                    if (pair.Key == "Chicken")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "chicken")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Sword")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "sword")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Shield")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "shield")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Fish")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "fish")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Keyboard")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "keyboard")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Club")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "club")
                            {
                                weaponB.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                }
                else
                {
                    var tempColor = weaponB.GetComponent<Image>().color;
                    tempColor.a = 0f;
                    weaponB.GetComponent<Image>().color = tempColor;
                }
            }

            if (l == 3)
            {
                if (pair.Value > 0)
                {
                    var tempColor = weaponC.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    weaponC.GetComponent<Image>().color = tempColor;

                    if (pair.Key == "Axe")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "axe")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }

                    }
                    if (pair.Key == "Chicken")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "chicken")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Sword")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "sword")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Shield")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "shield")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Fish")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "fish")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Keyboard")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "keyboard")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (pair.Key == "Club")
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "club")
                            {
                                weaponC.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                }
                else
                {
                    var tempColor = weaponC.GetComponent<Image>().color;
                    tempColor.a = 0f;
                    weaponC.GetComponent<Image>().color = tempColor;
                }
            }
        }
    }
}
