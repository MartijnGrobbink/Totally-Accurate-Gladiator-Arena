using System;
using Unity;
using UnityEngine;
using System.Collections.Generic;
public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    public int health;
    public int healthMax;

    private int damaged = 0;
    private float timer = 3f;
    private float timerHealth = 2f;

    //Audio
    public AudioSource DieSound;

    //AudioClips
    public List<AudioClip> death;
    public AudioClip DeathSound1;
    public AudioClip DeathSound2;
    public AudioClip DeathSound3;
    public AudioClip DeathSound4;

    void Start()
    {
        death.Add(DeathSound1);
        death.Add(DeathSound2);
        death.Add(DeathSound3);
        death.Add(DeathSound4);
    }

    void Update()
    {
        KillSelf();
        CheckToHeal();
    }

    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth() {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }

    //-----------------------For the Camera-----------------------------------
    public int getDamaged()
    {
        return damaged;
    }

    //------------------------------------------------------------------------

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);

        // to track the number of times an AI received damage on a certain sector 
        damaged++;
    }

    public void CheckToHeal()
    {
        if (health < 90 && health > 0)
        {
            if (timerHealth > 0)
            {
                timerHealth -= Time.deltaTime;
            }

            if (timerHealth <= 0)
            {
                Heal(10);
                timerHealth = 2f;
            }
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    private void KillSelf()
    {
        if (health <= 0)
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int x = UnityEngine.Random.Range(0, death.Count);
                DieSound.clip = death[x];
            }
        }
    }
}
