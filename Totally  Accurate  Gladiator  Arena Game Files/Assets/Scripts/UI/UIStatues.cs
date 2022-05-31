using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatues : MonoBehaviour
{
    public Image UIStatueStatusA;
    public Image UIStatueStatusB;
    //statue script has bool for which team is capping which sets on or off bool in respective team
    public Image TeamImageCapA;
    public Image TeamImageCapB;

    public Sprite Contested;
    public bool contestedA;
    public bool contestedB;

    void Start()
    {
        UIStatueStatusA = GameObject.Find("StatueStatusA").GetComponent<Image>();
        UIStatueStatusB = GameObject.Find("StatueStatusB").GetComponent<Image>();

        TeamImageCapA = GameObject.Find("TeamImageCapA").GetComponent<Image>();
        TeamImageCapB = GameObject.Find("TeamImageCapB").GetComponent<Image>();

        Contested = Resources.Load<Sprite>("StatueUI/ContestedStatueUI");
    }

    
    void Update()
    {
        SetContested();
    }

    public void SetContested()
    {
        if (contestedA == true)
        {
            UIStatueStatusA.sprite = Contested;

            var tempColor = TeamImageCapA.color;
            tempColor.a = 0f;
            TeamImageCapA.color = tempColor;
        }

        if (contestedB == true)
        {
            UIStatueStatusB.sprite = Contested;

            var tempColor = TeamImageCapB.color;
            tempColor.a = 0f;
            TeamImageCapB.color = tempColor;
        }
    }
}
