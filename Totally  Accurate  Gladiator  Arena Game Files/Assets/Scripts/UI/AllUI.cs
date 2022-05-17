using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllUI : MonoBehaviour
{
    // UI Sections ---
    public GameObject UISectionA;
    public GameObject UISectionB;
    public GameObject UISectionC;

    //UI SecionA ---
    public GameObject UITeamA;
    public GameObject UITeamB;
    public GameObject UITeamC;
    public GameObject UITeamD;
    public GameObject UITeamE;

    //UITeamA
    public GameObject UIBackgroundsTeamA;
    public Image UIBackgroundsTeamAEdge;
    public Image UIBackgroundsTeamALogo;
    public Image vBackgroundsTeamAPoints;

    public Image UITeamAImageLogo;
    public Text UITeamATextPoints;
    //UITeamB
    public GameObject UIBackgroundsTeamB;
    public Image UIBackgroundsTeamBEdge;
    public Image UIBackgroundsTeamBLogo;
    public Image UIBackgroundsTeamBPoints;

    public Image UITeamBImageLogo;
    public Text UITeamBTextPoints;
    //UITeamC
    public GameObject UIBackgroundsTeamC;
    public Image UIBackgroundsTeamCEdge;
    public Image UIBackgroundsTeamCLogo;
    public Image UIBackgroundsTeamCPoints;

    public Image UITeamCImageLogo;
    public Text UITeamCTextPoints;
    //UITeamD
    public GameObject UIBackgroundsTeamD;
    public Image UIBackgroundsTeamDEdge;
    public Image UIBackgroundsTeamDLogo;
    public Image UIBackgroundsTeamDPoints;

    public Image UITeamDImageLogo;
    public Text UITeamDTextPoints;
    //UITeamE
    public GameObject UIBackgroundsTeamE;
    public Image UIBackgroundsTeamEEdge;
    public Image UIBackgroundsTeamELogo;
    public Image UIBackgroundsTeamEPoints;

    public Image UITeamEImageLogo;
    public Text UITeamETextPoints;

    //UI SectionB ---
    public GameObject UISelectedTeam;
    public GameObject UITeamMemberStats;
    public GameObject UITeamStats;

    //UI TeamNameInfo
    public Image UITeamBackground;
    public Text UITeamNameText;

    //UI TeamMemberStats
    public GameObject UITeamMembers;
    public GameObject UITeamMembersWeapon;
    public GameObject UITeamMemberTextInfo;

    public Image UITeamMemberBackground;
    public Image UIMemberAImage;
    public Image UIMemberLeaderImage;
    public Image UIMemberBImage;

    public Image UITeamMemberAWeaponImage;
    public Image UITeamMemberLeaderWeaponImage;
    public Image UITeamMemberBWeaponImage;

    public GameObject UITeamMemberA;
    public GameObject UITeamMemberLeader;
    public GameObject UITeamMemberB;

    //UITeamMemberATextInfo
    public Text UITeamMemberAKillText;
    public Text UITeamMemberAKillsText;
    public Text UITeamMemberADeathText;
    public Text UITeamMemberADeathsText;
    public Text UITeamMemberAText;

    public Text UITeamMemberLeaderKillText;
    public Text UITeamMemberLeaderKillsText;
    public Text UITeamMemberLeaderDeathText;
    public Text UITeamMemberLeaderDeathsText;
    public Text UITeamMemberLeaderText;

    public Text UITeamMemberBKillText;
    public Text UITeamMemberBKillsText;
    public Text UITeamMemberBDeathText;
    public Text UITeamMemberBDeathsText;
    public Text UITeamMemberBText;

    //UITeamStats
    public Image UITeamStatsBackground;
    public GameObject UITeamsKilledInfo;
    public GameObject UIWeaponsUsedStats;

    public Text UITeamAKilledText;
    public Text UITeamAKillsText;
    public Text UITeamBKilledText;
    public Text UITeamBKillsText;
    public Text UITeamCKilledText;
    public Text UITeamCKillsText;
    public Text UITeamDKilledText;
    public Text UITeamDKillsText;

    public Text UIUsedText;
    public Text UIWeaponsText;
    public Image UIUsedWeaponA;
    public Image UIUsedWeaponB;
    public Image UIUsedWeaponC;


    //UI SecionC ---
    public Image UISectionCBackground;
    public GameObject UISectionCPartA;
    public GameObject UISectionCPartB;
    public GameObject UISectionCPartC;
    public GameObject UISectionCPartD;

    public Text UIKillerA;
    public Image UIWeaponA;
    public Text UIDeadA;

    public Text UIKillerB;
    public Image UIWeaponB;
    public Text UIDeadB;

    public Text UIKillerC;
    public Image UIWeaponC;
    public Text UIDeadC;

    public Text UIKillerD;
    public Image UIWeaponD;
    public Text UIDeadD;



    void Start()
    {
        UISectionA.SetActive(false);
        UISectionB.SetActive(false);
        UISectionC.SetActive(false);

        UIBackgroundsTeamA.SetActive(false);
        UITeamAImageLogo.enabled = false;

        UITeamBImageLogo.enabled = false;
        UITeamBTextPoints.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
