using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_End : MonoBehaviour
{
    public GameObject UI_Finish;
    public Text Points;
    public Text Winner;

    public List<int> teams;

    public int Cavemen;
    public int Romans;
    public int Vikings;
    public int Knights;
    public int Gamers;

    public GameObject Envo;

    public GameObject cavsScene;
    public GameObject romsScene;
    public GameObject viksScene;
    public GameObject kigsScene;
    public GameObject gamsScene;

    public GameObject cavs;
    public GameObject roms;
    public GameObject viks;
    public GameObject kigs;
    public GameObject gams;

    public GameObject cavsStart;
    public GameObject romsStart;
    public GameObject viksStart;
    public GameObject kigsStart;
    public GameObject gamsStart;

    private bool once;
    void Start()
    {
        UI_Finish.SetActive(false);

        romsScene = Instantiate(roms, romsStart.transform.position, Quaternion.identity, Envo.transform);
        cavsScene = Instantiate(cavs, cavsStart.transform.position, Quaternion.identity, Envo.transform);
        viksScene = Instantiate(viks, viksStart.transform.position, Quaternion.identity, Envo.transform);
        kigsScene = Instantiate(kigs, kigsStart.transform.position, Quaternion.identity, Envo.transform);
        gamsScene = Instantiate(gams, gamsStart.transform.position, Quaternion.identity, Envo.transform);

        cavsScene.SetActive(false);
        romsScene.SetActive(false);
        viksScene.SetActive(false);
        kigsScene.SetActive(false);
        gamsScene.SetActive(false);

        Cavemen = (Teams_Data.ScoreInfo["Cavemen"][1] * 5) + Teams_Data.ScoreInfo["Cavemen"][0];
        Romans = (Teams_Data.ScoreInfo["Romans"][1] * 5) + Teams_Data.ScoreInfo["Romans"][0];
        Gamers = (Teams_Data.ScoreInfo["Gamers"][1] * 5) + Teams_Data.ScoreInfo["Gamers"][0];
        Knights = (Teams_Data.ScoreInfo["Knights"][1] * 5) + Teams_Data.ScoreInfo["Knights"][0];
        Vikings = (Teams_Data.ScoreInfo["Vikings"][1] * 5) + Teams_Data.ScoreInfo["Vikings"][0];

        
    }

    
    void Update()
    {
        UI_Finish.SetActive(true);
        SetWinner();
    }

    private void SetWinner()
    {
        if (once == false)
        {
            teams.Add(Cavemen);
            teams.Add(Romans);
            teams.Add(Gamers);
            teams.Add(Knights);
            teams.Add(Vikings);
            once = true;
        }
       

        teams.Sort();
        if (Cavemen == teams[teams.Count - 1])
        {
            cavsScene.SetActive(true);
            Winner.text = "Cavemen Win!";
            string a = Cavemen.ToString();
            Points.text = a + " points";
        }

        if (Romans == teams[teams.Count - 1])
        {
            romsScene.SetActive(true);
            Winner.text = "Romans Win!";
            string a = Romans.ToString();
            Points.text = a + " points";
        }

        if (Vikings == teams[teams.Count - 1])
        {
            viksScene.SetActive(true);
            Winner.text = "Vikings Win!";
            string a = Vikings.ToString();
            Points.text = a + " points";
        }

        if (Knights == teams[teams.Count - 1])
        {
            kigsScene.SetActive(true);
            Winner.text = "Knights Win!";
            string a = Knights.ToString();
            Points.text = a + " points";
        }

        if (Gamers == teams[teams.Count - 1])
        {
            gamsScene.SetActive(true);
            Winner.text = "Gamers Win!";
            string a = Gamers.ToString();
            Points.text = a + " points";
        }

        if (teams[teams.Count - 1] == 0)
        {
            Winner.text = "No One Wins!";
            Points.text = "";
        }
    }
}
