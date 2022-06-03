using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITeamStats : MonoBehaviour
{
    public Text UITeamNameText;

    public GameObject UISectionB;

    public Text UITeamAKilledText;
    public Text UITeamAKillsText;
    public Text UITeamBKilledText;
    public Text UITeamBKillsText;
    public Text UITeamCKilledText;
    public Text UITeamCKillsText;
    public Text UITeamDKilledText;
    public Text UITeamDKillsText;

    public int TeamVikingsKills;
    public int TeamCavemenKills;
    public int TeamRomansKills;
    public int TeamKnightsKills;
    public int TeamGamersKills;

    public Image UIUsedWeaponA;
    public Image UIUsedWeaponB;
    public Image UIUsedWeaponC;

    public bool ActivateTeamSelected;

    public bool cavemenActive;
    public bool vikingsActive;
    public bool gamersActive;
    public bool romansActive;
    public bool knightsActive;

    public Sprite UsedWeaponSlotA;
    public Sprite UsedWeaponSlotB;
    public Sprite UsedWeaponSlotC;

    private bool once;

    void Start()
    {
        UISectionB = GameObject.Find("SelectedTeamUI");
        UITeamNameText = GameObject.Find("TeamNameText").GetComponent<Text>();
        UITeamAKillsText = GameObject.Find("TeamAKillsText").GetComponent<Text>();
        UITeamBKillsText = GameObject.Find("TeamBKillsText").GetComponent<Text>();
        UITeamCKillsText = GameObject.Find("TeamCKillsText").GetComponent<Text>();
        UITeamDKillsText = GameObject.Find("TeamDKillsText").GetComponent<Text>();
        UITeamAKilledText = GameObject.Find("TeamAKilledText").GetComponent<Text>();
        UITeamBKilledText = GameObject.Find("TeamBKilledText").GetComponent<Text>();
        UITeamCKilledText = GameObject.Find("TeamCKilledText").GetComponent<Text>();
        UITeamDKilledText = GameObject.Find("TeamDKilledText").GetComponent<Text>();
        UIUsedWeaponA = GameObject.Find("UsedWeapon1").GetComponent<Image>();
        UIUsedWeaponB = GameObject.Find("UsedWeapon2").GetComponent<Image>();
        UIUsedWeaponC = GameObject.Find("UsedWeapon3").GetComponent<Image>();

        var tempColor = UIUsedWeaponA.color;
        tempColor.a = 0f;
        UIUsedWeaponA.color = tempColor;

        UIUsedWeaponB.color = tempColor;
        UIUsedWeaponC.color = tempColor;
    }

    
    void Update()
    {
        if (once == false)
        {
            UISectionB.SetActive(false);
            once = true;
        }

        if (ActivateTeamSelected == false)
        {
            UISectionB.SetActive(false);
        }

        if (ActivateTeamSelected == true)
        {
            UISectionB.SetActive(true);
            CheckTeamActive();
            SetUsedWeapons();
        }
    }
    //team script will need to update before using teamactive bool from this script
    public void SetUsedWeapons()
    {
        if (UsedWeaponSlotA != null)
        {
            UIUsedWeaponA.sprite = UsedWeaponSlotA;
        }

        if (UsedWeaponSlotB != null)
        {
            UIUsedWeaponB.sprite = UsedWeaponSlotB;
        }

        if (UsedWeaponSlotC != null)
        {
            UIUsedWeaponC.sprite = UsedWeaponSlotC;
        }
    }

    //spectator script needs to turn on and off bool
    public void CheckTeamActive()
    {
        if (gamersActive == true && knightsActive == false && romansActive == false && cavemenActive == false && vikingsActive == false)
        {
            UITeamNameText.text = "Gamers";

            UITeamAKilledText.text = "Cavemen Killed";
            UITeamBKilledText.text = "Vikings Killed";
            UITeamCKilledText.text = "Knights Killed";
            UITeamDKilledText.text = "Romans Killed";

            UITeamAKillsText.text = TeamCavemenKills.ToString();
            UITeamBKillsText.text = TeamVikingsKills.ToString();
            UITeamCKillsText.text = TeamKnightsKills.ToString();
            UITeamDKillsText.text = TeamRomansKills.ToString();
        }

        if (knightsActive == true && gamersActive == false && romansActive == false && cavemenActive == false && vikingsActive == false)
        {
            UITeamNameText.text = "Knights";

            UITeamAKilledText.text = "Cavemen Killed";
            UITeamBKilledText.text = "Vikings Killed";
            UITeamCKilledText.text = "Gamers Killed";
            UITeamDKilledText.text = "Romans Killed";

            UITeamAKillsText.text = TeamCavemenKills.ToString();
            UITeamBKillsText.text = TeamVikingsKills.ToString();
            UITeamCKillsText.text = TeamGamersKills.ToString();
            UITeamDKillsText.text = TeamRomansKills.ToString();
        }

        if (romansActive == true && knightsActive == false && gamersActive == false && cavemenActive == false && vikingsActive == false)
        {
            UITeamNameText.text = "Romans";

            UITeamAKilledText.text = "Cavemen Killed";
            UITeamBKilledText.text = "Vikings Killed";
            UITeamCKilledText.text = "Knights Killed";
            UITeamDKilledText.text = "Gamers Killed";

            UITeamAKillsText.text = TeamCavemenKills.ToString();
            UITeamBKillsText.text = TeamVikingsKills.ToString();
            UITeamCKillsText.text = TeamKnightsKills.ToString();
            UITeamDKillsText.text = TeamGamersKills.ToString();
        }

        if (cavemenActive == true && knightsActive == false && romansActive == false && gamersActive == false && vikingsActive == false)
        {
            UITeamNameText.text = "Cavemen";

            UITeamAKilledText.text = "Gamers Killed";
            UITeamBKilledText.text = "Vikings Killed";
            UITeamCKilledText.text = "Knights Killed";
            UITeamDKilledText.text = "Romans Killed";

            UITeamAKillsText.text = TeamGamersKills.ToString();
            UITeamBKillsText.text = TeamVikingsKills.ToString();
            UITeamCKillsText.text = TeamKnightsKills.ToString();
            UITeamDKillsText.text = TeamRomansKills.ToString();
        }

        if (vikingsActive == true && knightsActive == false && romansActive == false && cavemenActive == false && gamersActive == false)
        {
            UITeamNameText.text = "Vikings";

            UITeamAKilledText.text = "Cavemen Killed";
            UITeamBKilledText.text = "Gamers Killed";
            UITeamCKilledText.text = "Knights Killed";
            UITeamDKilledText.text = "Romans Killed";

            UITeamAKillsText.text = TeamCavemenKills.ToString();
            UITeamBKillsText.text = TeamGamersKills.ToString();
            UITeamCKillsText.text = TeamKnightsKills.ToString();
            UITeamDKillsText.text = TeamRomansKills.ToString();
        }
    }
}
