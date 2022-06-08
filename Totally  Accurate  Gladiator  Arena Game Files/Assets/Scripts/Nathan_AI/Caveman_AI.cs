using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveman_AI : MonoBehaviour
{
    AIData data;
    Animator animator;
    bool EZKill = false;
    bool fleeing = false;
    public bool supported = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        data = GetComponent<AIData>();
        InvokeRepeating("check_supported", 0f, 5.0f);
    }

    void Offense()
    {
        for(int cou = 0; cou < data.enemies.Count; cou++)
        {
            var enemy_data = data.enemies[cou].GetComponent<AIData>();
            if (enemy_data.heldWeapon == null) {
                EZKill = true;
                data.chosenEnemy = data.enemies[cou];
            }
            else if (EZKill == false) {
                var enemy_power = enemy_data.heldWeapon.GetComponent<WeaponStats>();
                var my_power = data.heldWeapon.GetComponent<WeaponStats>();
                if (enemy_power.Damage + enemy_power.SwingSpeed <= my_power.Damage + my_power.SwingSpeed)
                {
                    data.chosenEnemy = data.enemies[cou];
                }
                else if (supported == true) {
                    data.chosenEnemy = data.enemies[cou];
                }
                else {
                    fleeing = true;
                }
            }
        }
        EZKill = false;
/*        if (data.signalSender == null)
            animator.Play("GroupUpSender");
        else {*/
            animator.Play("GoToEnemy");
//        }
/*        else { fleeing == true
            animator.Play("RunAway");
        }*/
        fleeing = false;
    }
    
    //checks if the character has allies near
    void check_supported()
    {
        if (data.ally.Count > 0)
            supported = true;
        else
            supported = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("SearchWeapon") != true)
        { 
            print("test");
        }
        if (data.enemies.Count == 0)
            data.chosenEnemy = null;
        if (data.heldWeapon == true && data.statue != null)
            animator.Play("GroupUpReceiver");
        if (data.weapons.Count > 0 && data.heldWeapon == null)
            data.chosenWeapon = data.weapons[0];
        else if (data.enemies.Count > 0)
        {
            if (data.heldWeapon == null) {
                animator.Play("RunAway");
            }
            else
            {
                Offense();
            }
        }
        else if (data.weapons.Count > 0 && data.heldWeapon != null) {
            for(int cou = 0; cou < data.weapons.Count; cou++)
            {
                var other_power = data.weapons[cou].GetComponent<WeaponStats>();
                var my_power = data.heldWeapon.GetComponent<WeaponStats>();
                if (other_power.Damage + other_power.SwingSpeed > my_power.Damage + my_power.SwingSpeed)
                {
                    data.heldWeapon = null;
                    animator.Play("SearchWeapon");
                    data.chosenWeapon = data.enemies[cou];
                }
            }
        }
    }
}
