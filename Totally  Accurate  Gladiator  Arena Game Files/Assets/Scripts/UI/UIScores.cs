using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScores : MonoBehaviour
{
    public UITeamStats UTS;

    public GameObject UITeamCavemen;
    public GameObject UITeamCavemenTarget;
    public GameObject UITeamCavemenStartPos;
    public Text UITeamCavemenTextPoints;

    public GameObject UITeamRomans;
    public GameObject UITeamRomansTarget;
    public GameObject UITeamRomansStartPos;
    public Text UITeamRomansTextPoints;

    public GameObject UITeamKnights;
    public GameObject UITeamKnightsTarget;
    public GameObject UITeamKnightsStartPos;
    public Text UITeamKnightsTextPoints;

    public GameObject UITeamVikings;
    public GameObject UITeamVikingsTarget;
    public GameObject UITeamVikingsStartPos;
    public Text UITeamVikingsTextPoints;

    public GameObject UITeamGamers;
    public GameObject UITeamGamersTarget;
    public GameObject UITeamGamersStartPos;
    public Text UITeamGamersTextPoints;

    void Start()
    {
        UTS = GameObject.FindObjectOfType<UITeamStats>();

        UITeamCavemen = GameObject.Find("CavemanTeam");
        UITeamRomans = GameObject.Find("RomanTeam");
        UITeamKnights = GameObject.Find("KnightsTeam");
        UITeamVikings = GameObject.Find("VikingTeam");
        UITeamGamers = GameObject.Find("GamerTeam");

        UITeamCavemenTarget = GameObject.Find("CavemanTeamTarget");
        UITeamRomansTarget = GameObject.Find("RomanTeamTarget");
        UITeamKnightsTarget = GameObject.Find("KnightsTeamTarget");
        UITeamVikingsTarget = GameObject.Find("VikingTeamTarget");
        UITeamGamersTarget = GameObject.Find("GamerTeamTarget");

        UITeamCavemenStartPos = GameObject.Find("CavemanTeamStartPos");
        UITeamRomansStartPos = GameObject.Find("RomanTeamStartPos");
        UITeamKnightsStartPos = GameObject.Find("KnightsTeamStartPos");
        UITeamVikingsStartPos = GameObject.Find("VikingTeamStartPos");
        UITeamGamersStartPos = GameObject.Find("GamerTeamStartPos");

        UITeamCavemenTextPoints = GameObject.Find("CavemanTextPoints").GetComponent<Text>();
        UITeamRomansTextPoints = GameObject.Find("RomanTextPoints").GetComponent<Text>();
        UITeamKnightsTextPoints = GameObject.Find("KnightsTextPoints").GetComponent<Text>();
        UITeamVikingsTextPoints = GameObject.Find("VikingTextPoints").GetComponent<Text>();
        UITeamGamersTextPoints = GameObject.Find("GamerTextPoints").GetComponent<Text>();

    }

    
    void Update()
    {
        CheckTeamActive();
    }

    public void CheckTeamActive()
    {
        if (UTS.gamersActive == false && UTS.knightsActive == false && UTS.romansActive == false && UTS.cavemenActive == false && UTS.vikingsActive == false)
        {
            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsStartPos.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);

            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenStartPos.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);

            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansStartPos.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);

            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsStartPos.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersStartPos.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);
        }

        if (UTS.gamersActive == true && UTS.knightsActive == false && UTS.romansActive == false && UTS.cavemenActive == false && UTS.vikingsActive == false)
        {
            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersTarget.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);

            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsStartPos.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);

            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenStartPos.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);

            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansStartPos.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);

            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsStartPos.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

        }

        if (UTS.knightsActive == true && UTS.gamersActive == false && UTS.romansActive == false && UTS.cavemenActive == false && UTS.vikingsActive == false)
        {
            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsTarget.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersStartPos.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);

            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsStartPos.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);

            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenStartPos.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);

            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansStartPos.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);
        }

        if (UTS.romansActive == true && UTS.knightsActive == false && UTS.gamersActive == false && UTS.cavemenActive == false && UTS.vikingsActive == false)
        {
            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansTarget.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);

            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsStartPos.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersStartPos.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);

            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsStartPos.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);

            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenStartPos.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);
        }

        if (UTS.cavemenActive == true && UTS.knightsActive == false && UTS.romansActive == false && UTS.gamersActive == false && UTS.vikingsActive == false)
        {
            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenTarget.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);

            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansStartPos.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);

            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsStartPos.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersStartPos.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);

            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsStartPos.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);
        }

        if (UTS.vikingsActive == true && UTS.knightsActive == false && UTS.romansActive == false && UTS.cavemenActive == false && UTS.gamersActive == false)
        {
            Vector3 startPositionvikings = UITeamVikings.transform.position;
            Vector3 targetvikings = UITeamVikingsTarget.transform.position;
            UITeamVikings.transform.position = Vector3.Lerp(startPositionvikings, targetvikings, 1);

            Vector3 startPositioncavemen = UITeamCavemen.transform.position;
            Vector3 targetcavemen = UITeamCavemenStartPos.transform.position;
            UITeamCavemen.transform.position = Vector3.Lerp(startPositioncavemen, targetcavemen, 1);

            Vector3 startPositionromans = UITeamRomans.transform.position;
            Vector3 targetromans = UITeamRomansStartPos.transform.position;
            UITeamRomans.transform.position = Vector3.Lerp(startPositionromans, targetromans, 1);

            Vector3 startPositionknights = UITeamKnights.transform.position;
            Vector3 targetknights = UITeamKnightsStartPos.transform.position;
            UITeamKnights.transform.position = Vector3.Lerp(startPositionknights, targetknights, 1);

            Vector3 startPositiongamers = UITeamGamers.transform.position;
            Vector3 targetgamers = UITeamGamersStartPos.transform.position;
            UITeamGamers.transform.position = Vector3.Lerp(startPositiongamers, targetgamers, 1);
        }
    }
}
