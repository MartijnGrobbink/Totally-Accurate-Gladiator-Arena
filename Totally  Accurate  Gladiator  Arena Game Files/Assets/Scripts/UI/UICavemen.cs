using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICavemen : MonoBehaviour
{
    public UITeamStats UTS;
    public UIMemberStats UMS;
    public UIScores USS;
    public UIStatues USTS;
    public List<int> kills;
    public List<int> MostUsed;

    //Left Hand Side Team Logo And Points
    public int CavemenPoints;

    //Middle Detailed UI Left Hand Side
    public Sprite CavemenMemberAImage;
    public Sprite CavemenMemberLeaderImage;
    public Sprite CavemenMemberBImage;

    //AI script would add its deaths and kills to these variables
    public int CavemenMemberAKills;
    public int CavemenMemberADeaths;

    public int CavemenMemberLeaderKills;
    public int CavemenMemberLeaderDeaths;

    public int CavemenMemberBKills;
    public int CavemenMemberBDeaths;
    //When A statue makes it to a teams base the statue script adds to this variable
    public int CapturedStatues;
    public int StatuePoints;
    public bool capturingA;
    public bool capturingB;
    //kills of each team
    public int GamersKilled;
    public int KnightsKilled;
    public int RomansKilled;
    public int VikingsKilled;
    //active weapon sprite is sent to these variables from each team member
    public Sprite CavemenMemberAActiveWeapon;
    public Sprite CavemenMemberLeaderActiveWeapon;
    public Sprite CavemenMemberBActiveWeapon;
    //number of uses of each weapon is added to each variable from each member
    public int axe;
    public int keyboard;
    public int fish;
    public int chicken;
    public int sword;
    public int shield;
    public int club;

    private int axeHold;
    private int keyboardHold;
    private int fishHold;
    private int chickenHold;
    private int swordHold;
    private int shieldHold;
    private int clubHold;

    private Sprite axeSprite;
    private Sprite keyboardSprite;
    private Sprite fishSprite;
    private Sprite chickenSprite;
    private Sprite swordSprite;
    private Sprite shieldSprite;
    private Sprite clubSprite;

    private Sprite CavemenStatue;
    private Sprite CavemenTeamStatue;

    public float timer;

    void Start()
    {
        UTS = GameObject.FindObjectOfType<UITeamStats>();
        UMS = GameObject.FindObjectOfType<UIMemberStats>();
        USS = GameObject.FindObjectOfType<UIScores>();
        USTS = GameObject.FindObjectOfType<UIStatues>();

        CavemenMemberAImage = Resources.Load<Sprite>("CharactersUI/cavemanfollowerA");
        CavemenMemberLeaderImage = Resources.Load<Sprite>("CharactersUI/cavemanleader");
        CavemenMemberBImage = Resources.Load<Sprite>("CharactersUI/cavemanfollowerB");

        axeSprite = Resources.Load<Sprite>("WeaponUI/axe");
        keyboardSprite = Resources.Load<Sprite>("WeaponUI/keyboard");
        fishSprite = Resources.Load<Sprite>("WeaponUI/fish");
        chickenSprite = Resources.Load<Sprite>("WeaponUI/chicken");
        swordSprite = Resources.Load<Sprite>("WeaponUI/sword");
        shieldSprite = Resources.Load<Sprite>("WeaponUI/shield");
        clubSprite = Resources.Load<Sprite>("WeaponUI/club");

        CavemenStatue = Resources.Load<Sprite>("StatueUI/CavemanStatueUI");
        CavemenTeamStatue = Resources.Load<Sprite>("CharactersUI/cavemanleader");

        StatuePoints = 10;
    }

    void Update()
    {
        SetScore();
        SetCapture();

        if (UTS.cavemenActive == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            

            if (timer <= 0)
            {
                MostUsed.Clear();
                kills.Clear();

                UTS.TeamGamersKills = GamersKilled;
                UTS.TeamKnightsKills = KnightsKilled;
                UTS.TeamRomansKills = RomansKilled;
                UTS.TeamVikingsKills = VikingsKilled;

                MostUsedWeapons();
                MostUsedCheckSlotA();
                MostUsedCheckSlotB();
                MostUsedCheckSlotC();

                SetMemberStats();
               

                timer = 2f;
            }
            
        }
       
    }

    public void SetCapture()
    {
        if (capturingA == true)
        {
            USTS.UIStatueStatusA.sprite = CavemenStatue;
            USTS.TeamImageCapA.sprite = CavemenTeamStatue;

            var tempColor = USTS.TeamImageCapA.color;
            tempColor.a = 1f;
            USTS.TeamImageCapA.color = tempColor;
        }

        if (capturingB == true)
        {
            USTS.UIStatueStatusB.sprite = CavemenStatue;
            USTS.TeamImageCapB.sprite = CavemenTeamStatue;

            var tempColor = USTS.TeamImageCapB.color;
            tempColor.a = 1f;
            USTS.TeamImageCapB.color = tempColor;
        }
    }

    public void SetScore()
    {
        int x = CavemenMemberBKills + CavemenMemberLeaderKills + CavemenMemberAKills + (CapturedStatues * StatuePoints);

        USS.UITeamCavemenTextPoints.text = x.ToString();
    }

    public void SetMemberStats()
    {
        UMS.UIMemberAImage.sprite = CavemenMemberAImage;
        UMS.UIMemberLeaderImage.sprite = CavemenMemberLeaderImage;
        UMS.UIMemberBImage.sprite = CavemenMemberBImage;

        //AI script would set the weapon sprite currently active
        if (CavemenMemberAActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberAWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberAWeaponImage.color = tempColor;
        }
        if (CavemenMemberAActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberAWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberAWeaponImage.color = tempColor;

            UMS.UITeamMemberAWeaponImage.sprite = CavemenMemberAActiveWeapon;
        }

        if (CavemenMemberLeaderActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberLeaderWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberLeaderWeaponImage.color = tempColor;
        }
        if (CavemenMemberLeaderActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberLeaderWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberLeaderWeaponImage.color = tempColor;

            UMS.UITeamMemberLeaderWeaponImage.sprite = CavemenMemberLeaderActiveWeapon;
        }

        if (CavemenMemberBActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberBWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberBWeaponImage.color = tempColor;
        }
        if (CavemenMemberBActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberBWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberBWeaponImage.color = tempColor;

            UMS.UITeamMemberBWeaponImage.sprite = CavemenMemberBActiveWeapon;
        }

        //AI script would set their kills and deaths 
        UMS.UITeamMemberAKillsText.text = CavemenMemberAKills.ToString();
        UMS.UITeamMemberADeathsText.text = CavemenMemberADeaths.ToString();

        UMS.UITeamMemberBKillsText.text = CavemenMemberBKills.ToString();
        UMS.UITeamMemberBDeathsText.text = CavemenMemberBDeaths.ToString();

        UMS.UITeamMemberLeaderKillsText.text = CavemenMemberLeaderKills.ToString();
        UMS.UITeamMemberLeaderDeathsText.text = CavemenMemberLeaderDeaths.ToString();
    }

    public void MostUsedWeapons()
    {
        axeHold = axe;
        chickenHold = chicken;
        swordHold = sword;
        shieldHold = shield;
        keyboardHold = keyboard;
        clubHold = club;
        fishHold = fish;

        MostUsed.Add(axe);
        MostUsed.Add(keyboard);
        MostUsed.Add(fish);
        MostUsed.Add(chicken);
        MostUsed.Add(sword);
        MostUsed.Add(shield);
        MostUsed.Add(club);

        MostUsed.Sort();

        for (int i = MostUsed.Count; i-- > 0;)
        {
            kills.Add(MostUsed[i]);
        }
    }
    //for the following if they have the same number it doesnt matter
    public void MostUsedCheckSlotA()
    {
        if (kills[0] == 0)
        {
            //return;
        }

        if (kills[0] == axeHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = axeSprite;
        }

        if (kills[0] == keyboardHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = keyboardSprite;
        }

        if (kills[0] == swordHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = swordSprite;
        }

        if (kills[0] == shieldHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = shieldSprite;
        }

        if (kills[0] == fishHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = fishSprite;
        }

        if (kills[0] == clubHold)
        {
            var tempColor = UTS.UIUsedWeaponA.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponA.color = tempColor;

            UTS.UsedWeaponSlotA = clubSprite;
        }
    }

    public void MostUsedCheckSlotB()
    {
        if (kills[1] == 0)
        {
            //return;
        }

        if (kills[1] == axeHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = axeSprite;
        }

        if (kills[1] == keyboardHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = keyboardSprite;
        }

        if (kills[1] == swordHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = swordSprite;
        }

        if (kills[1] == shieldHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = shieldSprite;
        }

        if (kills[1] == fishHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = fishSprite;
        }

        if (kills[1] == clubHold)
        {
            var tempColor = UTS.UIUsedWeaponB.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponB.color = tempColor;

            UTS.UsedWeaponSlotB = clubSprite;
        }
    }

    public void MostUsedCheckSlotC()
    {
        if (kills[2] == 0)
        {
            //return;
        }

        if (kills[2] == axeHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = axeSprite;
        }

        if (kills[2] == keyboardHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = keyboardSprite;
        }

        if (kills[2] == swordHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = swordSprite;
        }

        if (kills[2] == shieldHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = shieldSprite;
        }

        if (kills[2] == fishHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = fishSprite;
        }

        if (kills[2] == clubHold)
        {
            var tempColor = UTS.UIUsedWeaponC.color;
            tempColor.a = 1f;
            UTS.UIUsedWeaponC.color = tempColor;

            UTS.UsedWeaponSlotC = clubSprite;
        }
    }
}
