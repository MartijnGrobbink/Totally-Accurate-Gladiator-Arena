using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{
    // Stats To Be Applied To Weapon
    public string DesiredTag;

    public int SwingSpeed;
    public int SwingRate;
    public int Damage;

    public bool DazedEffect;
    public bool AOEEffect;
    public bool DurabilityEffect;
    public bool WaitEffect;

    public bool CanShieldAttack;
    public int TheDamage;
    //Actions To Be Taken With Weapon
    public GameObject EnemyAttacked;

    public bool DealDamage;
    public bool CanAttack;
    public bool Attacked;
    public bool HasSwung;

    //Images Of Each Weapon
    public Image WeaponInUse;

    public Image axe;
    public Image keyboard;
    public Image fish;
    public Image chicken;
    public Image sword;
    public Image shield;
    public Image club;

    [SerializeField] private LayerMask targetMask;
    public float radius;

    void Start()
    {
        //Applying Stats and Effects On Spawn
        if (DesiredTag == "Axe")
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

        if (DesiredTag == "Keyboard")
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

        if (DesiredTag == "Fish")
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

        if (DesiredTag == "Chicken")
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

        if (DesiredTag == "Sword")
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

        if (DesiredTag == "Shield")
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

        if (DesiredTag == "Club")
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
    }

    
    void Update()
    {
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
            var x = gameObject.transform.parent;
            if (x.gameObject.tag != other.gameObject.tag)
            {
                EnemyAttacked = other.gameObject;

                DealDamage = true;
            }

        }
        
    }
    //If The Weapon Has Colldied The Enemy It Collides With Is Damaged
    private void DamageEnemy()
    {
        EnemyAttacked.GetComponent<HealthSystem>().Damage(Damage);
        ApplyEffects();

        DealDamage = false;
    }
    //When Damaging The Enemy Effects Will Also Be Applied To The Enemy And Character
    private void ApplyEffects()
    {
        if (DazedEffect == true)
        {
            // ((TO DO)) Apply dazed effect on enemy
            //VFX
            //WaitEffect
        }

        if (AOEEffect)
        {
            Collider[] rangeChecks = Physics.OverlapSphere(EnemyAttacked.transform.position, radius, targetMask);
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                if (rangeChecks[i].gameObject != gameObject && rangeChecks[i].tag != "Weapon")
                    rangeChecks[i].gameObject.GetComponent<HealthSystem>().Damage(5);
            }
        }
        

        if (DurabilityEffect == true)
        {
            // ((TO DO)) Apply durability effect
            //add durability script to weapon
            //call durability function here
        }

        if (WaitEffect == true)
        {
            // ((TO DO)) Apply wait effect
            //where to add wait effect on AI
        }
    }
}
