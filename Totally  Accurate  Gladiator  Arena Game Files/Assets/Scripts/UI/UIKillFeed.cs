using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKillFeed : MonoBehaviour
{
    //Kill Feed on The Right Hand Side
    public Text UIKillerHold;
    public Image UIWeaponHold;
    public Text UIDeadHold;

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

    private string WeaponUsed;
    private string TeamKiller;
    private string TeamKilled;

    private bool SlotOne;
    private bool SlotTwo;
    private bool SlotThree;
    private bool SlotFour;


    void Start()
    {
        UIKillerHold = GameObject.Find("KillerHold").GetComponent<Text>();
        UIWeaponHold = GameObject.Find("WeaponHold").GetComponent<Image>();
        UIDeadHold = GameObject.Find("DeadHold").GetComponent<Text>();
        UIKillerA = GameObject.Find("KillerA").GetComponent<Text>();
        UIWeaponA = GameObject.Find("WeaponA").GetComponent<Image>();
        UIDeadA = GameObject.Find("DeadA").GetComponent<Text>();
        UIKillerB = GameObject.Find("KillerB").GetComponent<Text>();
        UIWeaponB = GameObject.Find("WeaponB").GetComponent<Image>();
        UIDeadB = GameObject.Find("DeadB").GetComponent<Text>();
        UIKillerC = GameObject.Find("KillerC").GetComponent<Text>();
        UIWeaponC = GameObject.Find("WeaponC").GetComponent<Image>();
        UIDeadC = GameObject.Find("DeadC").GetComponent<Text>();
        UIKillerD = GameObject.Find("KillerD").GetComponent<Text>();
        UIWeaponD = GameObject.Find("WeaponD").GetComponent<Image>();
        UIDeadD = GameObject.Find("DeadD").GetComponent<Text>();

        var tempColor = UIWeaponA.color;
        tempColor.a = 0f;
        UIWeaponA.color = tempColor;

        UIWeaponB.color = tempColor;
        UIWeaponC.color = tempColor;
        UIWeaponD.color = tempColor;

        UIKillerA.enabled = false;
        UIKillerB.enabled = false;
        UIKillerC.enabled = false;
        UIKillerD.enabled = false;

        UIDeadA.enabled = false;
        UIDeadB.enabled = false;
        UIDeadC.enabled = false;
        UIDeadD.enabled = false;
    }

    
    void Update()
    {

    }

    public void KilledEvent(string killer, byte killerteamR, byte killerteamG, byte killerteamB, Sprite weapon, string killed, byte killedteamR, byte killedteamG, byte killedteamB)
    {
        if (SlotOne == false)
        {
            UIKillerA.text = killer;
            UIKillerA.color = new Color32(killerteamR, killerteamG, killerteamB, 255);
            UIWeaponA.sprite = weapon;
            UIDeadA.text = killed;
            UIDeadA.color = new Color32(killedteamR, killedteamG, killedteamB, 255);

            var tempColor = UIWeaponA.color;
            tempColor.a = 1f;
            UIWeaponA.color = tempColor;

            UIKillerA.enabled = true;
            UIDeadA.enabled = true;

            SlotOne = true;
            return;
        }

        if (SlotOne == true && SlotTwo == false)
        {
            UIKillerHold.text = UIKillerA.text;
            UIKillerHold.color = UIKillerA.color;
            UIWeaponHold.sprite = UIWeaponA.sprite;
            UIDeadHold.text = UIDeadA.text;
            UIDeadHold.color = UIDeadA.color;

            UIKillerA.text = killer;
            UIKillerA.color = new Color32(killerteamR, killerteamG, killerteamB, 255);
            UIWeaponA.sprite = weapon;
            UIDeadA.text = killed;
            UIDeadA.color = new Color32(killedteamR, killedteamG, killedteamB, 255);

            UIKillerB.text = UIKillerHold.text;
            UIKillerB.color = UIKillerHold.color;
            UIWeaponB.sprite = UIWeaponHold.sprite;
            UIDeadB.text = UIDeadHold.text;
            UIDeadB.color = UIDeadHold.color;

            var tempColor = UIWeaponB.color;
            tempColor.a = 1f;
            UIWeaponB.color = tempColor;

            UIKillerB.enabled = true;
            UIDeadB.enabled = true;

            SlotTwo = true;
            return;
        }

        if (SlotOne == true && SlotTwo == true && SlotThree == false)
        {
            UIKillerC.text = UIKillerB.text;
            UIKillerC.color = UIKillerB.color;
            UIWeaponC.sprite = UIWeaponB.sprite;
            UIDeadC.text = UIDeadB.text;
            UIDeadC.color = UIDeadB.color;

            UIKillerB.text = UIKillerA.text;
            UIKillerB.color = UIKillerA.color;
            UIWeaponB.sprite = UIWeaponA.sprite;
            UIDeadB.text = UIDeadA.text;
            UIDeadB.color = UIDeadA.color;

            UIKillerA.text = killer;
            UIKillerA.color = new Color32(killerteamR, killerteamG, killerteamB, 255);
            UIWeaponA.sprite = weapon;
            UIDeadA.text = killed;
            UIDeadA.color = new Color32(killedteamR, killedteamG, killedteamB, 255);

            var tempColor = UIWeaponC.color;
            tempColor.a = 1f;
            UIWeaponC.color = tempColor;

            UIKillerC.enabled = true;
            UIDeadC.enabled = true;

            SlotThree = true;
            return;
        }

        if (SlotOne == true && SlotTwo == true && SlotThree == true && SlotFour == false)
        {
            UIKillerD.text = UIKillerC.text;
            UIKillerD.color = UIKillerC.color;
            UIWeaponD.sprite = UIWeaponC.sprite;
            UIDeadD.text = UIDeadC.text;
            UIDeadD.color = UIDeadC.color;

            UIKillerC.text = UIKillerB.text;
            UIKillerC.color = UIKillerB.color;
            UIWeaponC.sprite = UIWeaponB.sprite;
            UIDeadC.text = UIDeadB.text;
            UIDeadC.color = UIDeadB.color;

            UIKillerB.text = UIKillerA.text;
            UIKillerB.color = UIKillerA.color;
            UIWeaponB.sprite = UIWeaponA.sprite;
            UIDeadB.text = UIDeadA.text;
            UIDeadB.color = UIDeadA.color;

            UIKillerA.text = killer;
            UIKillerA.color = new Color32(killerteamR, killerteamG, killerteamB, 255);
            UIWeaponA.sprite = weapon;
            UIDeadA.text = killed;
            UIDeadA.color = new Color32(killedteamR, killedteamG, killedteamB, 255);

            var tempColor = UIWeaponD.color;
            tempColor.a = 1f;
            UIWeaponD.color = tempColor;

            UIKillerD.enabled = true;
            UIDeadD.enabled = true;

            return;
        }
    }

    //To Be Used In AI Script
    private void GetWeapon()
    {
        //Get Current Weapon
        var x = gameObject.GetComponent<WeaponStats>();
        var c = x.WeaponInUse;
        //Send This To KilledEvent As Image weapon
    }

    private void TeamName()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Cavemen"))
        {
            if (gameObject.tag == "FollowerA")
            {
                //UIChara = "Cavemen John";
            }

            if (gameObject.tag == "FollowerB")
            {
                //UIChara = "Cavemen Jim";
            }

            if (gameObject.tag == "Leader")
            {
                //UIChara = "Cavemen Jimmy";
            }

        }

        if (gameObject.layer == LayerMask.NameToLayer("Knights"))
        {
            if (gameObject.tag == "FollowerA")
            {
                //UIChara = "Knights John";
            }

            if (gameObject.tag == "FollowerB")
            {
                //UIChara = "Knights Jim";
            }

            if (gameObject.tag == "Leader")
            {
                //UIChara = "Knights Jimmy";
            }
        }

        if (gameObject.layer == LayerMask.NameToLayer("Gamers"))
        {
            if (gameObject.tag == "FollowerA")
            {
                //UIChara = "Gamers John";
            }

            if (gameObject.tag == "FollowerB")
            {
                //UIChara = "Gamers Jim";
            }

            if (gameObject.tag == "Leader")
            {
                //UIChara = "Gamers Jimmy";
            }
        }

        if (gameObject.layer == LayerMask.NameToLayer("Romans"))
        {
            if (gameObject.tag == "FollowerA")
            {
                //UIChara = "Romans John";
            }

            if (gameObject.tag == "FollowerB")
            {
                //UIChara = "Romans Jim";
            }

            if (gameObject.tag == "Leader")
            {
                //UIChara = "Romans Jimmy";
            }
        }

        if (gameObject.layer == LayerMask.NameToLayer("Vikings"))
        {
            if (gameObject.tag == "FollowerA")
            {
                //UIChara = "Vikings John";
            }

            if (gameObject.tag == "FollowerB")
            {
                //UIChara = "Vikings Jim";
            }

            if (gameObject.tag == "Leader")
            {
                //UIChara = "Vikings Jimmy";
            }
        }
    }

    private void SetColor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Cavemen"))
        {
            //floats
            //UIColorR = 106
            //UIColorG = 100
            //UIColorB = 86
        }

        if (gameObject.layer == LayerMask.NameToLayer("Knights"))
        {
            //UIColorR = 50
            //UIColorG = 50
            //UIColorB = 50
        }

        if (gameObject.layer == LayerMask.NameToLayer("Gamers"))
        {
            //UIColorR = 89
            //UIColorG = 161
            //UIColorB = 100
        }

        if (gameObject.layer == LayerMask.NameToLayer("Romans"))
        {
            //UIColorR = 192
            //UIColorG = 117
            //UIColorB = 117
        }

        if (gameObject.layer == LayerMask.NameToLayer("Vikings"))
        {
            //UIColorR = 183
            //UIColorG = 101
            //UIColorB = 179
        }
    }
}
