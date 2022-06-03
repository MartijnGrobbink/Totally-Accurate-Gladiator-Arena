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

                    var z = UR.TeamMembers[killed];
                    var a = z.transform.Find("TeamMemberDeathsText");
                    a.GetComponent<Text>().text = TD.CharacterInfo[killedteam][killed][1].ToString();
                }
            }
            
        }
    }

    public void TeamsWeaponUse(string team, string member, string weapon)
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
                        foreach(Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "axe")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                        
                    }
                    if (TD.CharacterInfo[team][member][2] == 1)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "chicken")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 2)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "sword")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 3)
                    {
                        foreach(Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "shield")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 4)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "fish")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 5)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "keyboard")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                    if (TD.CharacterInfo[team][member][2] == 6)
                    {
                        foreach (Sprite sprite in WA.WeaponImages)
                        {
                            if (sprite.name == "club")
                            {
                                x.GetComponent<Image>().sprite = sprite;
                            }
                        }
                    }
                }
            }
        }
    }

}
