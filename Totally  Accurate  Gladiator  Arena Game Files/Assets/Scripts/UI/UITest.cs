using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    //Team Stats
    public UICavemen UC;
    //Kill Feed
    public UIKillFeed UF;
    public string killer;
    public byte killerteamR;
    public byte killerteamG;
    public byte killerteamB;
    public string killed;
    public byte killedteamR;
    public byte killedteamG;
    public byte killedteamB;
    public Sprite TheWeapon;

    private Sprite axeSprite;
    private Sprite keyboardSprite;
    private Sprite fishSprite;
    private Sprite chickenSprite;
    private Sprite swordSprite;
    private Sprite shieldSprite;
    private Sprite clubSprite;

    public bool memberit;
    public bool doit;

    public bool cavemenkiller;
    public bool knightskiller;
    public bool gamerskiller;
    public bool romanskiller;
    public bool vikingskiller;

    public bool cavemenkilled;
    public bool knightskilled;
    public bool gamerskilled;
    public bool romanskilled;
    public bool vikingskilled;

    public bool theaxe;
    public bool thekeyboard;
    public bool thefish;
    public bool thechicken;
    public bool thesword;
    public bool theshield;
    public bool theclub;

    public bool MemberAtheaxe;
    public bool MemberAthekeyboard;
    public bool MemberBthefish;
    public bool MemberBthechicken;
    public bool MemberLeaderthesword;
    public bool MemberLeadertheshield;
    public bool MemberLeadertheclub;



    void Start()
    {
        UF = GameObject.FindObjectOfType<UIKillFeed>();
        UC = GameObject.FindObjectOfType<UICavemen>();

        axeSprite = Resources.Load<Sprite>("WeaponUI/axe");
        keyboardSprite = Resources.Load<Sprite>("WeaponUI/keyboard");
        fishSprite = Resources.Load<Sprite>("WeaponUI/fish");
        chickenSprite = Resources.Load<Sprite>("WeaponUI/chicken");
        swordSprite = Resources.Load<Sprite>("WeaponUI/sword");
        shieldSprite = Resources.Load<Sprite>("WeaponUI/shield");
        clubSprite = Resources.Load<Sprite>("WeaponUI/club");
    }

    
    void Update()
    {
        if (memberit == true)
        {
            SetImages();
            memberit = false;
        }

        if (doit == true)
        {
            Weapon();
            colorkilled();
            colorkiller();
            UF.KilledEvent(killer, killerteamR, killerteamG, killerteamB, TheWeapon, killed, killedteamR, killedteamG, killedteamB);
            doit = false;
        }
    }

    public void SetImages()
    {
        if (MemberAtheaxe == true)
        {
            UC.CavemenMemberAActiveWeapon = axeSprite;
        }
        if (MemberAthekeyboard == true)
        {
            UC.CavemenMemberAActiveWeapon = keyboardSprite;
        }
        if (MemberBthefish == true)
        {
            UC.CavemenMemberBActiveWeapon = fishSprite;
        }
        if (MemberBthechicken == true)
        {
            UC.CavemenMemberBActiveWeapon = chickenSprite;
        }
        if (MemberLeaderthesword == true)
        {
            UC.CavemenMemberLeaderActiveWeapon = swordSprite;
        }
        if (MemberLeadertheshield == true)
        {
            UC.CavemenMemberLeaderActiveWeapon = shieldSprite;
        }
        if (MemberLeadertheclub == true)
        {
            UC.CavemenMemberLeaderActiveWeapon = clubSprite;
        }
    }

    public void Weapon()
    {
        if (theaxe == true)
        {
            TheWeapon = axeSprite;
        }
        if (thekeyboard == true)
        {
            TheWeapon = keyboardSprite;
        }
        if (thefish == true)
        {
            TheWeapon = fishSprite;
        }
        if (thechicken == true)
        {
            TheWeapon = chickenSprite;
        }
        if (thesword == true)
        {
            TheWeapon = swordSprite;
        }
        if (theshield == true)
        {
            TheWeapon = shieldSprite;
        }
        if (theclub == true)
        {
            TheWeapon = clubSprite;
        }

    }

    public void colorkiller()
    {
        if (vikingskiller == true)
        {
            killerteamR = 183;
            killerteamG = 101;
            killerteamB = 179;
        }

        if (romanskiller == true)
        {
            killerteamR = 192;
            killerteamG = 117;
            killerteamB = 117;
        }

        if (gamerskiller == true)
        {
            killerteamR = 89;
            killerteamG = 161;
            killerteamB = 100;
        }

        if (knightskiller == true)
        {
            killerteamR = 50;
            killerteamG = 50;
            killerteamB = 50;
        }

        if (cavemenkiller == true)
        {
            killerteamR = 106;
            killerteamG = 100;
            killerteamB = 86;
        }
    }

    public void colorkilled()
    {
        if (vikingskilled == true)
        {
            killedteamR = 183;
            killedteamG = 101;
            killedteamB = 179;
        }

        if (romanskilled == true)
        {
            killedteamR = 192;
            killedteamG = 117;
            killedteamB = 117;
        }

        if (gamerskilled == true)
        {
            killedteamR = 89;
            killedteamG = 161;
            killedteamB = 100;
        }

        if (knightskilled == true)
        {
            killedteamR = 50;
            killedteamG = 50;
            killedteamB = 50;
        }

        if (cavemenkilled == true)
        {
            killedteamR = 106;
            killedteamG = 100;
            killedteamB = 86;
        }
    }
}
