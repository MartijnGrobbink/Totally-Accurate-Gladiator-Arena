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

    public GameObject cavs;
    public GameObject roms;
    public GameObject viks;
    public GameObject kigs;
    public GameObject gams;
    void Start()
    {
        UI_Finish.SetActive(false);

        cavs.SetActive(false);
        roms.SetActive(false);
        viks.SetActive(false);
        kigs.SetActive(false);
        gams.SetActive(false);

        Cavemen = (Teams_Data.ScoreInfo["Cavemen"][1] + 5) + Teams_Data.ScoreInfo["Cavemen"][0];
        Romans = (Teams_Data.ScoreInfo["Romans"][1] + 5) + Teams_Data.ScoreInfo["Romans"][0];
        Gamers = (Teams_Data.ScoreInfo["Gamers"][1] + 5) + Teams_Data.ScoreInfo["Gamers"][0];
        Knights = (Teams_Data.ScoreInfo["Knights"][1] + 5) + Teams_Data.ScoreInfo["Knights"][0];
        Vikings = (Teams_Data.ScoreInfo["Vikings"][1] + 5) + Teams_Data.ScoreInfo["Vikings"][0];

        
    }

    
    void Update()
    {
        UI_Finish.SetActive(true);
        SetWinner();
    }

    private void SetWinner()
    {
        teams.Add(Cavemen);
        teams.Add(Romans);
        teams.Add(Gamers);
        teams.Add(Knights);
        teams.Add(Vikings);

        teams.Sort();
        if (Cavemen == teams[0])
        {
            cavs.SetActive(true);
            Winner.text = "Cavemen Win!";
            Points.text = Cavemen + " points";
        }

        if (Romans == teams[0])
        {
            roms.SetActive(true);
            Winner.text = "Romans Win!";
            Points.text = Romans + " points";
        }

        if (Vikings == teams[0])
        {
            viks.SetActive(true);
            Winner.text = "Vikings Win!";
            Points.text = Vikings + " points";
        }

        if (Knights == teams[0])
        {
            kigs.SetActive(true);
            Winner.text = "Knights Win!";
            Points.text = Knights + " points";
        }

        if (Gamers == teams[0])
        {
            gams.SetActive(true);
            Winner.text = "Gamers Win!";
            Points.text = Gamers + " points";
        }
    }
}
