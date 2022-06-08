using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Timer : MonoBehaviour
{
    private float timer = 60f;
    private bool loaded;
    void Start()
    {
    }


    void Update()
    {
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}

