using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_End : MonoBehaviour
{
    public GameObject UI_Finish;
    public GameObject Section1;
    public GameObject Section2;
    public GameObject Section3;
    public GameObject Section4;
    public GameObject Section5;
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


    private float timer = 60f;
    private bool loaded;
    void Start()
    {
        UI_Finish.SetActive(false);

        cavs.SetActive(false);
        roms.SetActive(false);
        viks.SetActive(false);
        kigs.SetActive(false);
        gams.SetActive(false);
    }

    
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);

        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            loaded = true;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (loaded == true)
        {
            Section1.SetActive(false);
            Section2.SetActive(false);
            Section3.SetActive(false);
            Section4.SetActive(false);
            Section5.SetActive(false);
            UI_Finish.SetActive(true);
            SetWinner();
        }
    }

    private void SetWinner()
    {
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
