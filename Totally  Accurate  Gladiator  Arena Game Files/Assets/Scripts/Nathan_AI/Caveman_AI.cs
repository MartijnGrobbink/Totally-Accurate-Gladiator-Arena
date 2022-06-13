using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveman_AI : MonoBehaviour
{
    AIData data;
    Animator animator;
    bool EZKill = false;
    bool fleeing = false;
    bool no_enemies = false;
    public bool supported = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        data = GetComponent<AIData>();
        InvokeRepeating("check_supported", 0f, 5.0f);
    }

    private void setState(string name)
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName(name) != true)
        {
            animator.Play(name);
        }
    }

    void Offense()
    {
        for(int cou = 0; cou < data.enemies.Count; cou++)
        {
            if (data.enemies[cou] == null) {
                no_enemies = true;
                break;
            }
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
        if (no_enemies == false){
            if (fleeing == false){
                setState("GoToEnemy");
            }
            else {
                setState("RunAway");
            }
        }
        else
            setState("SearchWeapon");
        no_enemies = false;
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

    IEnumerator support_cooldown()
    {
        yield return new WaitForSeconds(5f);
        supported = false;
    }
    // Update is called once per frame
    void Update()
    {
        var weap = gameObject.GetComponentInChildren<WeaponStats>();
        if (weap == null)
            data.heldWeapon = null;
        if (data.ally.Count > 0 && supported == false) {
            supported = true;
            StartCoroutine(support_cooldown());
        }
/*        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("SearchWeapon") != true)
        { 
            print("test");
        }*/
        if (data.enemies.Count == 0) {
            data.chosenEnemy = null;
            setState("SearchWeapon");
        }
        if (data.weapons.Count > 0 && data.heldWeapon == null)
            data.chosenWeapon = data.weapons[0];
        else if (data.enemies.Count > 0)
        {
            if (data.heldWeapon == null) {
                setState("RunAway");
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
//                    data.heldWeapon = null;
                    data.chosenWeapon = data.weapons[cou];
                }
            }
        }
    }
}
