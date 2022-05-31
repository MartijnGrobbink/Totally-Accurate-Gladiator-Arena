using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMemberStats : MonoBehaviour
{
    public UITeamStats UTS;

    public Image UIMemberAImage;
    public Image UIMemberLeaderImage;
    public Image UIMemberBImage;

    public Image UITeamMemberAWeaponImage;
    public Image UITeamMemberLeaderWeaponImage;
    public Image UITeamMemberBWeaponImage;

    public Text UITeamMemberAKillsText;
    public Text UITeamMemberADeathsText;

    public Text UITeamMemberLeaderKillsText;
    public Text UITeamMemberLeaderDeathsText;

    public Text UITeamMemberBKillsText;
    public Text UITeamMemberBDeathsText;

    void Start()
    {
        UTS = GameObject.FindObjectOfType<UITeamStats>();

        UIMemberAImage = GameObject.Find("TeamMemberAImage").GetComponent<Image>();
        UIMemberBImage = GameObject.Find("MemberBImage").GetComponent<Image>();
        UIMemberLeaderImage = GameObject.Find("TeamMemberLeaderImage").GetComponent<Image>();

        UITeamMemberAWeaponImage = GameObject.Find("TeamMemberAWeaponImage").GetComponent<Image>();
        UITeamMemberLeaderWeaponImage = GameObject.Find("TeamMemberLeaderWeaponImage").GetComponent<Image>();
        UITeamMemberBWeaponImage = GameObject.Find("MemberBWeaponImage").GetComponent<Image>();

        UITeamMemberAKillsText = GameObject.Find("TeamMemberAKillsText").GetComponent<Text>();
        UITeamMemberADeathsText = GameObject.Find("TeamMemberADeathsText").GetComponent<Text>();
        UITeamMemberLeaderKillsText = GameObject.Find("TeamMemberLeaderKillsText").GetComponent<Text>();
        UITeamMemberLeaderDeathsText = GameObject.Find("TeamMemberLeaderDeathsText").GetComponent<Text>();
        UITeamMemberBKillsText = GameObject.Find("TeamMemberBKillsText").GetComponent<Text>();
        UITeamMemberBDeathsText = GameObject.Find("TeamMemberBDeathsText").GetComponent<Text>();
    }

    
    void Update()
    {

    }
}
