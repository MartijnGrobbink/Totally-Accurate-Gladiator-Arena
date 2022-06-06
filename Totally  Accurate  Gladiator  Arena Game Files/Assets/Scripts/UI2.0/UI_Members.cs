using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Members : MonoBehaviour
{
    public UI_Refs UR;
    public Teams_Data TD;
    public Weapon_Assets WA;


    public void MemberHasKilled(string killer, string killerteam, string killed, string killedteam)
    {
        foreach (KeyValuePair<string, int> pair in UR.TeamActive)
        {
            if (pair.Value == 1)
            {
                if (pair.Key == killerteam)
                {
                    var y = UR.TeamMembers[killer];
                    var x = y.transform.Find("TeamMemberKillsText");
                    x.GetComponent<Text>().text = TD.CharacterInfo[killerteam][killer][0].ToString();
                }

                if (pair.Key == killedteam)
                {
                    var z = UR.TeamMembers[killed];
                    var a = z.transform.Find("TeamMemberDeathsText");
                    a.GetComponent<Text>().text = TD.CharacterInfo[killedteam][killed][1].ToString();
                }
            }
            
        }
    }

    public void TeamsWeaponUse(string team, string member)
    {
        foreach (KeyValuePair<string, int> pair in UR.TeamActive)
        {
            if (pair.Value == 1)
            {
                if (pair.Key == team)
                {
                    var y = UR.TeamMembers[member];
                    var x = y.transform.Find("TeamMemberWeaponImage");

                    if (TD.CharacterInfo[team][member][2] == 0)
                    {
                        var tempColor = x.GetComponent<Image>().color;
                        tempColor.a = 0f;
                        x.GetComponent<Image>().color = tempColor;

                    }

                    if (TD.CharacterInfo[team][member][2] == 1)
                    {
                        foreach(Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "axe")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                        
                    }
                    if (TD.CharacterInfo[team][member][2] == 2)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "chicken")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 3)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "sword")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 4)
                    {
                        foreach(Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "shield")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 5)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "fish")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 6)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "keyboard")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 7)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "club")
                            {
                                x.GetComponent<Image>().sprite = sprite;

                                var tempColor = x.GetComponent<Image>().color;
                                tempColor.a = 1f;
                                x.GetComponent<Image>().color = tempColor;
                            }
                        }
                    }
                }
            }
        }
    }

    public void NewTeamsWeaponUse(string team)
    {
        //Member A
        var y = UR.TeamMembers["MemberA"];
        var x = y.transform.Find("TeamMemberWeaponImage");

        if (TD.CharacterInfo[team]["MemberA"][2] == 0)
        {
            var tempColor = x.GetComponent<Image>().color;
            tempColor.a = 0f;
            x.GetComponent<Image>().color = tempColor;

        }

        if (TD.CharacterInfo[team]["MemberA"][2] == 1)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "axe")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }

        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 2)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "chicken")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 3)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "sword")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 4)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "shield")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 5)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "fish")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 6)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "keyboard")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberA"][2] == 7)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "club")
                {
                    x.GetComponent<Image>().sprite = sprite;

                    var tempColor = x.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    x.GetComponent<Image>().color = tempColor;
                }
            }
        }

        //Member B
        var z = UR.TeamMembers["MemberB"];
        var a = z.transform.Find("TeamMemberWeaponImage");

        if (TD.CharacterInfo[team]["MemberB"][2] == 0)
        {
            var tempColor = a.GetComponent<Image>().color;
            tempColor.a = 0f;
            a.GetComponent<Image>().color = tempColor;

        }

        if (TD.CharacterInfo[team]["MemberB"][2] == 1)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "axe")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }

        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 2)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "chicken")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 3)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "sword")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 4)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "shield")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 5)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "fish")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 6)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "keyboard")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["MemberB"][2] == 7)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "club")
                {
                    a.GetComponent<Image>().sprite = sprite;

                    var tempColor = a.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    a.GetComponent<Image>().color = tempColor;
                }
            }
        }

        //Leader
        var b = UR.TeamMembers["Leader"];
        var c = b.transform.Find("TeamMemberWeaponImage");

        if (TD.CharacterInfo[team]["Leader"][2] == 0)
        {
            var tempColor = c.GetComponent<Image>().color;
            tempColor.a = 0f;
            c.GetComponent<Image>().color = tempColor;

        }

        if (TD.CharacterInfo[team]["Leader"][2] == 1)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "axe")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }

        }
        if (TD.CharacterInfo[team]["Leader"][2] == 2)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "chicken")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["Leader"][2] == 3)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "sword")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["Leader"][2] == 4)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "shield")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["Leader"][2] == 5)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "fish")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["Leader"][2] == 6)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "keyboard")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
        if (TD.CharacterInfo[team]["Leader"][2] == 7)
        {
            foreach (Sprite sprite in WA.WeaponImages)
            {
                if (sprite.name == "club")
                {
                    c.GetComponent<Image>().sprite = sprite;

                    var tempColor = c.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    c.GetComponent<Image>().color = tempColor;
                }
            }
        }
    }

}
