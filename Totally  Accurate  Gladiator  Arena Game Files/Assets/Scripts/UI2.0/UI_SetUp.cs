using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetUp : MonoBehaviour
{
    public UI_Refs UR;
    public UI_Score US;
    public UI_Statue UST;

    void Start()
    {
        //Setting Up Members UI
        var MemberA = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);
        var Leader = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);
        var MemberB = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);

        UR.TeamMembers.Add("MemberA", MemberA);
        UR.TeamMembers.Add("Leader", Leader);
        UR.TeamMembers.Add("MemberB", MemberB);

        var aaa = UR.TeamMembers["MemberA"];
        var weaponaaa = aaa.transform.Find("TeamMemberWeaponImage");

        var tempColor = weaponaaa.GetComponent<Image>().color;
        tempColor.a = 0f;
        weaponaaa.GetComponent<Image>().color = tempColor;

        var bbb = UR.TeamMembers["Leader"];
        var weaponbbb = bbb.transform.Find("TeamMemberWeaponImage");

        tempColor = weaponbbb.GetComponent<Image>().color;
        tempColor.a = 0f;
        weaponbbb.GetComponent<Image>().color = tempColor;

        var ccc = UR.TeamMembers["MemberB"];
        var weaponccc = ccc.transform.Find("TeamMemberWeaponImage");

        tempColor = weaponccc.GetComponent<Image>().color;
        tempColor.a = 0f;
        weaponccc.GetComponent<Image>().color = tempColor;

        //Setting Up Teams UI
        var TeamA = Instantiate(UR.TeamsKilledInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.TeamsKilledInfoLayout.transform);
        var TeamB = Instantiate(UR.TeamsKilledInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.TeamsKilledInfoLayout.transform);
        var TeamC = Instantiate(UR.TeamsKilledInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.TeamsKilledInfoLayout.transform);
        var TeamD = Instantiate(UR.TeamsKilledInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.TeamsKilledInfoLayout.transform);

        UR.TeamsKilled.Add("TeamA", TeamA);
        UR.TeamsKilled.Add("TeamB", TeamB);
        UR.TeamsKilled.Add("TeamC", TeamC);
        UR.TeamsKilled.Add("TeamD", TeamD);

        var WeaponA = Instantiate(UR.WeaponsUsedPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.WeaponsUsedLayout.transform);
        var WeaponB = Instantiate(UR.WeaponsUsedPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.WeaponsUsedLayout.transform);
        var WeaponC = Instantiate(UR.WeaponsUsedPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.WeaponsUsedLayout.transform);

        UR.WeaponsUsed.Add("WeaponA", WeaponA);
        UR.WeaponsUsed.Add("WeaponB", WeaponB);
        UR.WeaponsUsed.Add("WeaponC", WeaponC);

        var y = UR.WeaponsUsed["WeaponA"];
        var weapona = y.transform.Find("UsedWeapon");

        tempColor = weapona.GetComponent<Image>().color;
        tempColor.a = 0f;
        weapona.GetComponent<Image>().color = tempColor;

        var x = UR.WeaponsUsed["WeaponB"];
        var weaponb = x.transform.Find("UsedWeapon");

        tempColor = weaponb.GetComponent<Image>().color;
        tempColor.a = 0f;
        weaponb.GetComponent<Image>().color = tempColor;

        var z = UR.WeaponsUsed["WeaponC"];
        var weaponc = z.transform.Find("UsedWeapon");

        tempColor = weaponc.GetComponent<Image>().color;
        tempColor.a = 0f;
        weaponc.GetComponent<Image>().color = tempColor;

        //Setting Up Kill Feed UI
        var KillA = Instantiate(UR.KillLogPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.KillLogLayout.transform);
        var KillB = Instantiate(UR.KillLogPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.KillLogLayout.transform);
        var KillC = Instantiate(UR.KillLogPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.KillLogLayout.transform);
        var KillD = Instantiate(UR.KillLogPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.KillLogLayout.transform);

        UR.KillLogs.Add("KillD", KillA);
        UR.KillLogs.Add("KillC", KillB);
        UR.KillLogs.Add("KillB", KillC);
        UR.KillLogs.Add("KillA", KillD);

        var a = UR.KillLogs["KillA"];
        var killa = a.transform.Find("Weapon");

        tempColor = killa.GetComponent<Image>().color;
        tempColor.a = 0f;
        killa.GetComponent<Image>().color = tempColor;

        var b = UR.KillLogs["KillB"];
        var killb = b.transform.Find("Weapon");

        tempColor = killb.GetComponent<Image>().color;
        tempColor.a = 0f;
        killb.GetComponent<Image>().color = tempColor;

        var c = UR.KillLogs["KillC"];
        var killc = c.transform.Find("Weapon");

        tempColor = killc.GetComponent<Image>().color;
        tempColor.a = 0f;
        killc.GetComponent<Image>().color = tempColor;

        var d = UR.KillLogs["KillD"];
        var killd = d.transform.Find("Weapon");

        tempColor = killd.GetComponent<Image>().color;
        tempColor.a = 0f;
        killd.GetComponent<Image>().color = tempColor;
        //Setting Up Score UI
        var ScoreA = Instantiate(UR.ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.ScoreLayout.transform);
        var ScoreB = Instantiate(UR.ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.ScoreLayout.transform);
        var ScoreC = Instantiate(UR.ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.ScoreLayout.transform);
        var ScoreD = Instantiate(UR.ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.ScoreLayout.transform);
        var ScoreE = Instantiate(UR.ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.ScoreLayout.transform);

        UR.Scores.Add("Cavemen", ScoreA);
        UR.Scores.Add("Vikings", ScoreB);
        UR.Scores.Add("Romans", ScoreC);
        UR.Scores.Add("Knights", ScoreD);
        UR.Scores.Add("Gamers", ScoreE);

        US.SetTeamLogos();
        //Setting up Statue
        var StatueA = Instantiate(UR.StatuePrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.StatueLayout.transform);

        UR.Statues.Add("StatueA", StatueA);

        var aa = UR.Statues["StatueA"];
        var statueaa = aa.transform.Find("TeamImageCap");

        tempColor = statueaa.GetComponent<Image>().color;
        tempColor.a = 0f;
        statueaa.GetComponent<Image>().color = tempColor;

        UST.SetStatueLogo();
    }
}
