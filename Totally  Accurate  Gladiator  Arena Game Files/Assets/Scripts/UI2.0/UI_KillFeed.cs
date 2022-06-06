using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_KillFeed : MonoBehaviour
{
    public UI_Refs UR;
    public Teams_Data TD;
    public Weapon_Assets WA;

    public int logged;

    public void MemberHasKilled(string killer, string killerteam, string weapon, string killed, string killedteam)
    {
        logged = logged + 1;
        CheckSlots();
        SetNames(killer, killerteam, killed, killedteam);
        CheckTeamColor(killerteam, killedteam);
        CheckWeapon(weapon);
    }

    private void SetNames(string killer, string killerteam, string killed, string killedteam)
    {
        TeamName(killer, killerteam, killed, killedteam);
    }

    private void TeamName(string killer, string killerteam, string killed, string killedteam)
    {
        //Killer Name
        if (killerteam == "Cavemen")
        {
            if (killer == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Cavemen John";
            }

            if (killer == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Cavemen Jim";
            }

            if (killer == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Cavemen Jimmy";
            }

        }

        if (killerteam == "Knights")
        {
            if (killer == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Knights John";
            }

            if (killer == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Knights Jim";
            }

            if (killer == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Knights Jimmy";
            }
        }

        if (killerteam == "Gamers")
        {
            if (killer == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Gamers John";
            }

            if (killer == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Gamers Jim";
            }

            if (killer == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Gamers Jimmy";
            }
        }

        if (killerteam == "Romans")
        {
            if (killer == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Romans John";
            }

            if (killer == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Romans Jim";
            }

            if (killer == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Romans Jimmy";
            }
        }

        if (killerteam == "Vikings")
        {
            if (killer == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Vikings John";
            }

            if (killer == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Vikings Jim";
            }

            if (killer == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Killer");
                killa.GetComponent<Text>().text = "Vikings Jimmy";
            }
        }
        //Killed Name
        if (killedteam == "Cavemen")
        {
            if (killed == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Cavemen John";
            }

            if (killed == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Cavemen Jim";
            }

            if (killed == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Cavemen Jimmy";
            }

        }

        if (killedteam == "Knights")
        {
            if (killed == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Knights John";
            }

            if (killed == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Knights Jim";
            }

            if (killed == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Knights Jimmy";
            }
        }

        if (killedteam == "Gamers")
        {
            if (killed == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Gamers John";
            }

            if (killed == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Gamers Jim";
            }

            if (killed == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Gamers Jimmy";
            }
        }

        if (killedteam == "Romans")
        {
            if (killed == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Romans John";
            }

            if (killed == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Romans Jim";
            }

            if (killed == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Romans Jimmy";
            }
        }

        if (killedteam == "Vikings")
        {
            if (killed == "MemberA")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Vikings John";
            }

            if (killed == "MemberB")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Vikings Jim";
            }

            if (killed == "Leader")
            {
                var a = UR.KillLogs["KillA"];
                var killa = a.transform.Find("Dead");
                killa.GetComponent<Text>().text = "Vikings Jimmy";
            }
        }
    }

    private void CheckWeapon(string weapon)
    {
        FindWeaponSprite(weapon);
    }

    private void FindWeaponSprite(string weapon)
    {
        var a = UR.KillLogs["KillA"];
        var imagea = a.transform.Find("Weapon");

        foreach (Sprite sprite in WA.WeaponImages)
        {
            if (weapon == "Axe")
            {
                if (sprite.name == "axe")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Sword")
            {
                if (sprite.name == "sword")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Shield")
            {
                if (sprite.name == "shield")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Keyboard")
            {
                if (sprite.name == "keyboard")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Fish")
            {
                if (sprite.name == "fish")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Chicken")
            {
                if (sprite.name == "chicken")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }

            if (weapon == "Club")
            {
                if (sprite.name == "club")
                {
                    imagea.GetComponent<Image>().sprite = sprite;
                }
            }
        }
    }

    private void CheckTeamColor(string killerteam, string killedteam)
    {
        KillerTeamCheck(killerteam);

        KilledTeamCheck(killedteam);
    }

    private void CheckSlots()
    {

        if (logged >= 4)
        {
            SlotC();

            var d = UR.KillLogs["KillD"];
            var killd = d.transform.Find("Weapon");

            var tempColor = killd.GetComponent<Image>().color;
            tempColor.a = 1f;
            killd.GetComponent<Image>().color = tempColor;
        }

        if (logged >= 3)
        {
            SlotB();

            var c = UR.KillLogs["KillC"];
            var killc = c.transform.Find("Weapon");

            var tempColor = killc.GetComponent<Image>().color;
            tempColor.a = 1f;
            killc.GetComponent<Image>().color = tempColor;
        }

        if (logged >= 2)
        {
            SlotA();

            var b = UR.KillLogs["KillB"];
            var killb = b.transform.Find("Weapon");

            var tempColor = killb.GetComponent<Image>().color;
            tempColor.a = 1f;
            killb.GetComponent<Image>().color = tempColor;
        }

        if (logged == 1)
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Weapon");

            var tempColor = killa.GetComponent<Image>().color;
            tempColor.a = 1f;
            killa.GetComponent<Image>().color = tempColor;
        }
    }

    private void SlotA()
    {
        //Slot A Elements
        var a = UR.KillLogs["KillA"];
        var killa = a.transform.Find("Killer");
        var killacolor = killa.GetComponent<Text>().color;
        var killatext = killa.GetComponent<Text>().text;

        var da = UR.KillLogs["KillA"];
        var deada = da.transform.Find("Dead");
        var deadacolor = deada.GetComponent<Text>().color;
        var deadatext = deada.GetComponent<Text>().text;

        var ia = UR.KillLogs["KillA"];
        var imagea = ia.transform.Find("Weapon");
        var imageasprite = imagea.GetComponent<Image>().sprite;
        //Slot B Elements
        var b = UR.KillLogs["KillB"];
        var killb = b.transform.Find("Killer");
        killb.GetComponent<Text>().color = killacolor;
        killb.GetComponent<Text>().text = killatext;

        var db = UR.KillLogs["KillB"];
        var deadb = db.transform.Find("Dead");
        deadb.GetComponent<Text>().color = deadacolor;
        deadb.GetComponent<Text>().text = deadatext;

        var ib = UR.KillLogs["KillB"];
        var imageb = ib.transform.Find("Weapon");
        imageb.GetComponent<Image>().sprite = imageasprite;
    }

    private void SlotB()
    {
        //Slot B Elements
        var b = UR.KillLogs["KillB"];
        var killb = b.transform.Find("Killer");
        var killbcolor = killb.GetComponent<Text>().color;
        var killbtext = killb.GetComponent<Text>().text;

        var db = UR.KillLogs["KillB"];
        var deadb = db.transform.Find("Dead");
        var deadbcolor = deadb.GetComponent<Text>().color;
        var deadbtext = deadb.GetComponent<Text>().text;

        var ib = UR.KillLogs["KillB"];
        var imageb = ib.transform.Find("Weapon");
        var imagebsprite = imageb.GetComponent<Image>().sprite;
        //Slot C Elements
        var c = UR.KillLogs["KillC"];
        var killc = c.transform.Find("Killer");
        killc.GetComponent<Text>().color = killbcolor;
        killc.GetComponent<Text>().text = killbtext;

        var dc = UR.KillLogs["KillC"];
        var deadc = dc.transform.Find("Dead");
        deadc.GetComponent<Text>().color = deadbcolor;
        deadc.GetComponent<Text>().text = deadbtext;

        var ic = UR.KillLogs["KillC"];
        var imagec = ic.transform.Find("Weapon");
        imagec.GetComponent<Image>().sprite = imagebsprite;
    }

    private void SlotC()
    {
        //Slot C Elements
        var c = UR.KillLogs["KillC"];
        var killc = c.transform.Find("Killer");
        var killccolor = killc.GetComponent<Text>().color;
        var killctext = killc.GetComponent<Text>().text;

        var dc = UR.KillLogs["KillC"];
        var deadc = dc.transform.Find("Dead");
        var deadccolor = deadc.GetComponent<Text>().color;
        var deadctext = deadc.GetComponent<Text>().text;

        var ic = UR.KillLogs["KillC"];
        var imagec = ic.transform.Find("Weapon");
        var imagecsprite = imagec.GetComponent<Image>().sprite;
        //Slot D Elements
        var d = UR.KillLogs["KillD"];
        var killd = d.transform.Find("Killer");
        killd.GetComponent<Text>().color = killccolor;
        killd.GetComponent<Text>().text = killctext;

        var dd = UR.KillLogs["KillD"];
        var deadd = dd.transform.Find("Dead");
        deadd.GetComponent<Text>().color = deadccolor;
        deadd.GetComponent<Text>().text = deadctext;

        var id = UR.KillLogs["KillD"];
        var imaged = id.transform.Find("Weapon");
        imaged.GetComponent<Image>().sprite = imagecsprite;
    }

    private void KillerTeamCheck(string killerteam)
    {
        if (killerteam == "Vikings")
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Killer");
            killa.GetComponent<Text>().color = new Color32(183, 101, 179, 255);
        }

        if (killerteam == "Romans")
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Killer");
            killa.GetComponent<Text>().color = new Color32(192, 117, 117, 255);
        }

        if (killerteam == "Gamers")
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Killer");
            killa.GetComponent<Text>().color = new Color32(89, 161, 100, 255);
        }

        if (killerteam == "Knights")
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Killer");
            killa.GetComponent<Text>().color = new Color32(50, 50, 50, 255);
        }

        if (killerteam == "Cavemen")
        {
            var a = UR.KillLogs["KillA"];
            var killa = a.transform.Find("Killer");
            killa.GetComponent<Text>().color = new Color32(106, 100, 86, 255);
        }
    }

    private void KilledTeamCheck(string killedteam)
    {
        if (killedteam == "Vikings")
        {
            var a = UR.KillLogs["KillA"];
            var deada = a.transform.Find("Dead");
            deada.GetComponent<Text>().color = new Color32(183, 101, 179, 255);
        }

        if (killedteam == "Romans")
        {
            var a = UR.KillLogs["KillA"];
            var deada = a.transform.Find("Dead");
            deada.GetComponent<Text>().color = new Color32(192, 117, 117, 255);
        }

        if (killedteam == "Gamers")
        {
            var a = UR.KillLogs["KillA"];
            var deada = a.transform.Find("Dead");
            deada.GetComponent<Text>().color = new Color32(89, 161, 100, 255);
        }

        if (killedteam == "Knights")
        {
            var a = UR.KillLogs["KillA"];
            var deada = a.transform.Find("Dead");
            deada.GetComponent<Text>().color = new Color32(50, 50, 50, 255);
        }

        if (killedteam == "Cavemen")
        {
            var a = UR.KillLogs["KillA"];
            var deada = a.transform.Find("Dead");
            deada.GetComponent<Text>().color = new Color32(106, 100, 86, 255);
        }
    }
}
