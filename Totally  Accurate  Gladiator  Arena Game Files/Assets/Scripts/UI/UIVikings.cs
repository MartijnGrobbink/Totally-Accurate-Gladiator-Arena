using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVikings : MonoBehaviour
{
    public UITeamStats UTS;
    public UIMemberStats UMS;
    public UIScores USS;
    public UIStatues USTS;
    public List<int> kills;
    public List<int> MostUsed;

    //Left Hand Side Team Logo And Points
    public int VikingsPoints;

    //Middle Detailed UI Left Hand Side
    public Sprite VikingsMemberAImage;
    public Sprite VikingsMemberLeaderImage;
    public Sprite VikingsMemberBImage;

    //AI script would add its deaths and kills to these variables
    public int VikingsMemberAKills;
    public int VikingsMemberADeaths;

    public int VikingsMemberLeaderKills;
    public int VikingsMemberLeaderDeaths;

    public int VikingsMemberBKills;
    public int VikingsMemberBDeaths;
    //When A statue makes it to a teams base the statue script adds to this variable
    public int CapturedStatues;
    public int StatuePoints;
    public bool capturingA;
    public bool capturingB;
    //kills of each team
    public int GamersKilled;
    public int KnightsKilled;
    public int RomansKilled;
    public int CavemenKilled;
    //active weapon sprite is sent to these variables from each team member
    public Sprite VikingsMemberAActiveWeapon;
    public Sprite VikingsMemberLeaderActiveWeapon;
    public Sprite VikingsMemberBActiveWeapon;
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

    private Sprite VikingsStatue;
    private Sprite VikingsTeamStatue;

    public float timer;

    void Start()
    {
        UTS = GameObject.FindObjectOfType<UITeamStats>();
        UMS = GameObject.FindObjectOfType<UIMemberStats>();
        USS = GameObject.FindObjectOfType<UIScores>();
        USTS = GameObject.FindObjectOfType<UIStatues>();

        VikingsMemberAImage = Resources.Load<Sprite>("CharactersUI/vikingfollowerA");
        VikingsMemberLeaderImage = Resources.Load<Sprite>("CharactersUI/vikingleader");
        VikingsMemberBImage = Resources.Load<Sprite>("CharactersUI/vikingfollowerB");

        axeSprite = Resources.Load<Sprite>("WeaponUI/axe");
        keyboardSprite = Resources.Load<Sprite>("WeaponUI/keyboard");
        fishSprite = Resources.Load<Sprite>("WeaponUI/fish");
        chickenSprite = Resources.Load<Sprite>("WeaponUI/chicken");
        swordSprite = Resources.Load<Sprite>("WeaponUI/sword");
        shieldSprite = Resources.Load<Sprite>("WeaponUI/shield");
        clubSprite = Resources.Load<Sprite>("WeaponUI/club");

        VikingsStatue = Resources.Load<Sprite>("StatueUI/VikingStatueUI");
        VikingsTeamStatue = Resources.Load<Sprite>("CharactersUI/Vikingleader");

        StatuePoints = 10;
    }

    void Update()
    {
        SetScore();
        SetCapture();

        if (UTS.vikingsActive == true)
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
                UTS.TeamCavemenKills = CavemenKilled;

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
            USTS.UIStatueStatusA.sprite = VikingsStatue;
            USTS.TeamImageCapA.sprite = VikingsTeamStatue;

            var tempColor = USTS.TeamImageCapA.color;
            tempColor.a = 1f;
            USTS.TeamImageCapA.color = tempColor;
        }

        if (capturingB == true)
        {
            USTS.UIStatueStatusB.sprite = VikingsStatue;
            USTS.TeamImageCapB.sprite = VikingsTeamStatue;

            var tempColor = USTS.TeamImageCapB.color;
            tempColor.a = 1f;
            USTS.TeamImageCapB.color = tempColor;
        }
    }

    public void SetScore()
    {
        int x = VikingsMemberBKills + VikingsMemberLeaderKills + VikingsMemberAKills + (CapturedStatues * StatuePoints);

        USS.UITeamVikingsTextPoints.text = x.ToString();
    }

    public void SetMemberStats()
    {
        UMS.UIMemberAImage.sprite = VikingsMemberAImage;
        UMS.UIMemberLeaderImage.sprite = VikingsMemberLeaderImage;
        UMS.UIMemberBImage.sprite = VikingsMemberBImage;

        //AI script would set the weapon sprite currently active
        if (VikingsMemberAActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberAWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberAWeaponImage.color = tempColor;
        }
        if (VikingsMemberAActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberAWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberAWeaponImage.color = tempColor;

            UMS.UITeamMemberAWeaponImage.sprite = VikingsMemberAActiveWeapon;
        }

        if (VikingsMemberLeaderActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberLeaderWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberLeaderWeaponImage.color = tempColor;
        }
        if (VikingsMemberLeaderActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberLeaderWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberLeaderWeaponImage.color = tempColor;

            UMS.UITeamMemberLeaderWeaponImage.sprite = VikingsMemberLeaderActiveWeapon;
        }

        if (VikingsMemberBActiveWeapon == null)
        {
            var tempColor = UMS.UITeamMemberBWeaponImage.color;
            tempColor.a = 0f;
            UMS.UITeamMemberBWeaponImage.color = tempColor;
        }
        if (VikingsMemberBActiveWeapon != null)
        {
            var tempColor = UMS.UITeamMemberBWeaponImage.color;
            tempColor.a = 1f;
            UMS.UITeamMemberBWeaponImage.color = tempColor;

            UMS.UITeamMemberBWeaponImage.sprite = VikingsMemberBActiveWeapon;
        }

        //AI script would set their kills and deaths 
        UMS.UITeamMemberAKillsText.text = VikingsMemberAKills.ToString();
        UMS.UITeamMemberADeathsText.text = VikingsMemberADeaths.ToString();

        UMS.UITeamMemberBKillsText.text = VikingsMemberBKills.ToString();
        UMS.UITeamMemberBDeathsText.text = VikingsMemberBDeaths.ToString();

        UMS.UITeamMemberLeaderKillsText.text = VikingsMemberLeaderKills.ToString();
        UMS.UITeamMemberLeaderDeathsText.text = VikingsMemberLeaderDeaths.ToString();
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
