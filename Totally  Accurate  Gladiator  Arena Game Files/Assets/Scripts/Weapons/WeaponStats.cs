using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{
    // Stats To Be Applied To Weapon
    public string DesiredTag;
    public GameObject Wielder;

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
    GameObject RealEnemyAttacked;
    playerController pc;

    public bool DealDamage;
    public bool CanAttack;
    public bool Attacked;
    public bool HasSwung;

    //Audio
    public AudioSource HitSound;

    //AudioClips
    public AudioClip SwordSound;
    public AudioClip ShieldSound;
    public AudioClip FishSound;
    public AudioClip KeyboardSound;
    public AudioClip AxeSound;
    public AudioClip ClubSound;
    public AudioClip ChickenSound;

    [SerializeField] private LayerMask targetMask;
    public float radius;

    void Start()
    {
        //Applying Stats and Effects On Spawn
        if (DesiredTag == "Axe")
        {
            SwingSpeed = 5;
            SwingRate = 10;
            Damage = 90;

            DazedEffect = false;
            AOEEffect = false;
            DurabilityEffect = false;
            WaitEffect = true;

            CanShieldAttack = false;

            HitSound.clip = AxeSound;
        }

        if (DesiredTag == "Keyboard")
        {
            SwingSpeed = 10;
            SwingRate = 2;
            Damage = 30;

            DazedEffect = false;
            AOEEffect = true;
            DurabilityEffect = true;
            WaitEffect = true;

            CanShieldAttack = false;

            HitSound.clip = KeyboardSound;
        }

        if (DesiredTag == "Fish")
        {
            SwingSpeed = 12;
            SwingRate = 2;
            Damage = 30;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = false;

            CanShieldAttack = false;

            HitSound.clip = FishSound;
        }

        if (DesiredTag == "Chicken")
        {
            SwingSpeed = 15;
            SwingRate = 1;
            Damage = 45;

            DazedEffect = false;
            AOEEffect = false;
            DurabilityEffect = false;
            WaitEffect = false;

            CanShieldAttack = false;

            HitSound.clip = ChickenSound;
        }

        if (DesiredTag == "Sword")
        {
            SwingSpeed = 7;
            SwingRate = 4;
            Damage = 70;

            DazedEffect = false;
            AOEEffect = true;
            DurabilityEffect = false;
            WaitEffect = false;

            CanShieldAttack = false;

            HitSound.clip = SwordSound;
        }

        if (DesiredTag == "Shield")
        {
            SwingSpeed = 15;
            SwingRate = 10;
            Damage = 90;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = true;

            CanShieldAttack = true;

            HitSound.clip = ShieldSound;
        }

        if (DesiredTag == "Club")
        {
            SwingSpeed = 10;
            SwingRate = 2;
            Damage = 50;

            DazedEffect = true;
            AOEEffect = false;
            DurabilityEffect = true;
            WaitEffect = false;

            CanShieldAttack = false;

            HitSound.clip = ClubSound;
        }
    }

    
    void Update()
    {
        //When The Weapon Has Connected With An Enemy
        if (DealDamage == true)
        {
            if (HitSound != null)
            {
                HitSound.Play();
            }
            
            DamageEnemy();
        }
    }
    //Check For If The Weapon Colldier Colldies With A Character (yes can TK)
    private void OnTriggerEnter(Collider other)
    {
        if (DealDamage == false)
        {
            //finds the parent object contining AI data of the attacked enemy
            var g = 1;
            var t = other.gameObject.transform.parent;
            var c = other.gameObject.transform.parent;
            for (int i = 0; i < g; i++)
            {
                if (t == null)
                {
                    t = c;
                    g = 0;
                }
                else
                {
                    c = t;
                    t = t.gameObject.transform.parent;
                    g = g + 1;
                }
            }

            var x = gameObject.transform.parent;
            if (x != null)
            {
                if (t != null)
                {
                    if (Wielder.tag != t.tag)
                    {
                        //sets the attacked enemy as a variable that can be called on later
                        if (t.GetComponent<AIData>())
                        {
                            EnemyAttacked = t.gameObject;

                            DealDamage = true;
                        }

                    }
                }
                
            }
            

        }
        
    }
    //If The Weapon Has Colldied The Enemy It Collides With Is Damaged
    private void DamageEnemy()
    {
        if (EnemyAttacked.GetComponent<HealthSystem>().health - Damage <= 0)
        {
            Teams_EventManager.current.HasKilled(Wielder.GetComponent<AIData>().MemberName, Wielder.GetComponent<AIData>().TeamName, DesiredTag, EnemyAttacked.GetComponent<AIData>().MemberName, EnemyAttacked.GetComponent<AIData>().TeamName);
        }
        EnemyAttacked.GetComponent<HealthSystem>().Damage(Damage);
        ApplyEffects();

        DealDamage = false;
    }
    //When Damaging The Enemy Effects Will Also Be Applied To The Enemy And Character
    private void ApplyEffects()
    {
        //dazed the enemy if the correct weapon is being used
        Dazed();

        //applies damage to enemies wihtin a radius if the correct weapon is being used
        AOE();

        //applies damage to the weapon if the correct weapon is being used
        Durability();

        //has the character wait until they can attack if the correct weapon is used
        Wait(); 
    }

    private void Dazed()
    {
        if (DazedEffect == true)
        {
            RealEnemyAttacked = EnemyAttacked.transform.Find("metarig").gameObject;
            RealEnemyAttacked = RealEnemyAttacked.transform.Find("spine").gameObject;
            pc = RealEnemyAttacked.GetComponent<playerController>();
            pc.stun = true;
            Wielder.GetComponent<Animator>().SetBool("Effects", true);
        }
    }

    private void AOE()
    {
        if (AOEEffect)
        {
            Collider[] rangeChecks = Physics.OverlapSphere(EnemyAttacked.transform.position, radius, targetMask);
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                if (rangeChecks[i].gameObject != gameObject && rangeChecks[i].tag != "Weapon")
                    rangeChecks[i].gameObject.GetComponent<HealthSystem>().Damage(5);
            }
        }
    }

    private void Durability()
    {
        if (DurabilityEffect == true)
        {
            gameObject.GetComponent<Durability>().HitSomething();
        }
    }

    private void Wait()
    {
        if (WaitEffect == true)
        {
            Wielder.GetComponent<Animator>().SetBool("Effects", true);
        }
    }
}
