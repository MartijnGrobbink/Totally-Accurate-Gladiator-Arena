using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{
    // Stats To Be Applied To Weapon
    public int SwingSpeed;
    public int SwingRate;
    public int Damage;

    public bool DazedEffect;
    public bool AOEEffect;
    public bool DurabilityEffect;
    public bool WaitEffect;

    public bool CanShieldAttack;
    //Actions To Be Taken With Weapon
    public GameObject EnemyAttacked;

    public bool DealDamage;
    public bool CanAttack;
    public bool Attacked;
    public bool HasSwung;

    private float SwingCooldown;
    private float SwingTime;

    //Images Of Each Weapon
    public Image WeaponInUse;

    public Image axe;
    public Image keyboard;
    public Image fish;
    public Image chicken;
    public Image sword;
    public Image shield;
    public Image club;


    void Start()
    {
        //Applying Stats and Effects On Spawn
        if (gameObject.tag == "Axe")
        {
            SwingSpeed = 5;
            SwingRate = 10;
            Damage = 15;

            DazedEffect = false;
            AOEEffect = false;
            DurabilityEffect = false;
            WaitEffect = true;

            CanShieldAttack = false;
            WeaponInUse = axe;
        }

        if (gameObject.tag == "Keyboard")
        {
            SwingSpeed = 10;
            SwingRate = 2;
            Damage = 7;

            DazedEffect = false;
            AOEEffect = true;
            DurabilityEffect = true;
            WaitEffect = true;

            CanShieldAttack = false;
            WeaponInUse = keyboard;
        }

        if (gameObject.tag == "Fish")
        {
            SwingSpeed = 12;
            SwingRate = 2;
            Damage = 7;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = false;

            CanShieldAttack = false;
            WeaponInUse = fish;
        }

        if (gameObject.tag == "Chicken")
        {
            SwingSpeed = 15;
            SwingRate = 1;
            Damage = 8;

            DazedEffect = false;
            AOEEffect = false;
            DurabilityEffect = false;
            WaitEffect = false;

            CanShieldAttack = false;
            WeaponInUse = chicken;
        }

        if (gameObject.tag == "Sword")
        {
            SwingSpeed = 7;
            SwingRate = 4;
            Damage = 13;

            DazedEffect = false;
            AOEEffect = true;
            DurabilityEffect = false;
            WaitEffect = false;

            CanShieldAttack = false;
            WeaponInUse = sword;
        }

        if (gameObject.tag == "Shield")
        {
            SwingSpeed = 15;
            SwingRate = 10;
            Damage = 15;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = true;

            CanShieldAttack = true;
            WeaponInUse = shield;
        }

        if (gameObject.tag == "Club")
        {
            SwingSpeed = 10;
            SwingRate = 2;
            Damage = 9;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = false;

            CanShieldAttack = false;
            WeaponInUse = club;
        }

        //Setting variables
        SwingCooldown = SwingRate;
        SwingTime = SwingSpeed;
        CanAttack = true;
    }

    
    void Update()
    {
        //When Character Attacks
        if (/*Character attacks  (THE FOLLOWING IS FILLER SO IT SAVES)*/Attacked == true)
        {
            Attacked = true;
        }
        //When The Character Is In The Process Of Attacking
        if (Attacked == true)
        {
            Check();
        }
        //When The Character Is Able To Attack
        if (CanAttack == true)
        {
            ReadyAttack();
        }
        //When The Character Is In The Process Of Attacking 
        if (HasSwung == true)
        {
            WaitForSwing();
        }
        //When The Weapon Has Connected With An Enemy
        if (DealDamage == true)
        {
            DamageEnemy();
        }
    }
    //Check For If The Weapon Colldier Colldies With A Character (yes can TK)
    private void OnTriggerEnter(Collider other)
    {
        if (DealDamage == false && Attacked == true)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
            {
                EnemyAttacked = other.gameObject;

                DealDamage = true;
            }
        }
        
    }
    //If The Weapon Has Colldied The Enemy It Collides With Is Damaged
    private void DamageEnemy()
    {
        Attacked = false;
        SwingTime = SwingSpeed;
        // ((TO DO)) apply damage to enemy health script
        ApplyEffects();

        DealDamage = false;
    }
    //When Damaging The Enemy Effects Will Also Be Applied To The Enemy And Character
    private void ApplyEffects()
    {
        if (DazedEffect == true)
        {
            // ((TO DO)) Apply dazed effect on enemy
        }

        if (AOEEffect == true)
        {
            // ((TO DO)) Apply AOE effect 
        }

        if (DurabilityEffect == true)
        {
            // ((TO DO)) Apply durability effect
        }

        if (WaitEffect == true)
        {
            // ((TO DO)) Apply wait effect
        }
    }
    //Once The Character Has Attacked They Will Need To Wait To Attack Again
    private void WaitForSwing()
    {
        Attacked = false;
        SwingCooldown -= Time.deltaTime;

        if (SwingCooldown == 0)
        {
            CanAttack = true;
        }
    }
    //Once The Character Swing Cooldown Has Expired The Character Can Attack Again
    private void ReadyAttack()
    {
        HasSwung = false;
        SwingCooldown = SwingRate;
    }
    //If The Character Attacks And Hits Nothing The Swing Cooldown Will Be Activated
    private void Check()
    {
        SwingTime -= Time.deltaTime;

        if (SwingTime == 0)
        {
            HasSwung = true;
        }
    }
}
