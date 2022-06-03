using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetUp : MonoBehaviour
{
    public UI_Refs UR;
    void Start()
    {
        //Setting Up Members UI
        var MemberA = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);
        var Leader = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);
        var MemberB = Instantiate(UR.MembersPrefab, new Vector3(0, 0, 0), Quaternion.identity, UR.MembersLayout.transform);

        UR.TeamMembers.Add("MemberA", MemberA);
        UR.TeamMembers.Add("Leader", Leader);
        UR.TeamMembers.Add("MemberB", MemberB);

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

        var tempColor = weapona.GetComponent<Image>().color;
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
    }
}
