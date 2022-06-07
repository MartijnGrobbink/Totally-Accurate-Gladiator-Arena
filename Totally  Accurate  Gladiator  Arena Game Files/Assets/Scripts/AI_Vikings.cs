using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Vikings : MonoBehaviour
{
    AIData data;
    Animator animator;
    HealthSystem healthsystem;

    private bool weaponActive;
    private bool weaponSet;
    private bool masterWeapon;
    private float timer;
    private int masterChecked;

    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
        healthsystem = gameObject.GetComponent<HealthSystem>();

        //healthsystem.HealthSystem(75);

    }

    void Update()
    {
        CheckTimer();
        GettingWeaponState();
        SetWeaponStats();
    }
    private void SwitchStates(string enterStateName)
    {
        TurnOffVariables();

        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName(enterStateName) != true)
        {
            animator.Play(enterStateName);
        }
        else
        {
            return;
        }
           
    }
    private void AttackState()
    {
        CheckHighestDamage();
        SwitchStates("GoToEnemy");
    }
    private void RunAwayState()
    {
        SwitchStates("RunAway");
    }

    private void GettingWeaponState()
    {
        if (data.heldWeapon == null)
        {
            if (data.weapons.Count != 0)
            {
                if (timer <= 0 && masterChecked < 2)
                {
                    MasterWeapon();
                }

                if (masterWeapon == true)
                {
                    masterChecked = 0;
                    SwitchStates("GrabWeapon");
                }

                if (masterChecked >= 2)
                {
                    data.chosenWeapon = data.weapons[0];
                    SwitchStates("GrabWeapon");
                }
                
            }
        }
        else if (data.chosenEnemy != null)
        {
            if (data.heldWeapon != null)
            {
                AttackState();
            }
            else
            {
                RunAwayState();
            }
                
        }
        else
        {
            GroupUpState();
        }
           
    }

    private void GroupUpState()
    {
        if (data.enemies.Count != 0)
        {
            AttackState();
        }
        else
        {
            if (data.signalSender == null)
            {
                SwitchStates("GroupUpSender");
            }
            else
            {
                SwitchStates("GroupUpReciever");
            }
                
        }
    }

    private void MasterWeapon()
    {
        var l = 0;
        List<GameObject> possibleWeapon = new List<GameObject>();
        foreach (GameObject weapon in data.weapons)
        {
            if (weapon.GetComponent<WeaponStats>().DesiredTag == "Axe")
            {
                possibleWeapon.Add(weapon);
                l = l + 1;
            }

            if (l == 0 && weapon.GetComponent<WeaponStats>().SwingRate < 5)
            {
                possibleWeapon.Add(weapon);
                l = l + 1;
            }
        }

        if (l == 0)
        {
            masterChecked = masterChecked + 1;
            timer = 3f;
        }

        if (l >= 1)
        {
            data.chosenWeapon = possibleWeapon[0];
            masterWeapon = true;
        }
    }

    private void CheckHighestDamage()
    {
        var l = 0;
        List<GameObject> possibleEnemies = new List<GameObject>();
        foreach (GameObject enemy in data.enemies)
        {
            var a = enemy.GetComponent<AIData>();
            if (a.heldWeapon != null)
            {
                var b = a.heldWeapon;
                var c = b.GetComponent<WeaponStats>();

                if (c.Damage > 10)
                {
                    possibleEnemies.Add(enemy);
                    l = l + 1;
                }
            }
            
        }

        if (l == 0)
        {
            data.chosenEnemy = data.enemies[0];
        }

        if (l >= 1)
        {
            data.chosenEnemy = possibleEnemies[0];
        }
    }

    private void SetWeaponStats()
    {
        if (data.heldWeapon == null && weaponActive == true && weaponSet == true)
        {
            weaponActive = false;
        }

        if (data.heldWeapon != null && weaponActive == false)
        {
            weaponSet = false;
            weaponActive = true;
        }

        if (weaponActive == true && weaponSet == false)
        {
            data.heldWeapon.GetComponent<WeaponStats>().SwingRate = data.heldWeapon.GetComponent<WeaponStats>().SwingRate / 2;
            weaponSet = true;
        }
    }

    private void CheckTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void TurnOffVariables()
    {
        masterWeapon = false;
    }
}
