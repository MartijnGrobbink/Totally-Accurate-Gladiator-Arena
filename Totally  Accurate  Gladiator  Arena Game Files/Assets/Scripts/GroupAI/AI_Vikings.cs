using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Vikings : MonoBehaviour
{
    AIData data;
    Animator animator;
    HealthSystem healthsystem;

    public float thedist;
    private bool weaponActive;
    private bool weaponSet;
    private bool masterWeapon;
    private float timer;
    private int masterChecked;
    private bool once;
    private bool canGroupUp;
    private bool canRecover;

    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
        healthsystem = gameObject.GetComponent<HealthSystem>();
        healthsystem.healthMax = 75;
        canGroupUp = true;
        canRecover = true;
    }

    void Update()
    {
        //Setting states and checking for states if certain states are not already active
        AnimatorStateInfo setState = animator.GetCurrentAnimatorStateInfo(0);
        if (setState.IsName("Effects") != true)
        {
            if (setState.IsName("AttackLocationState") != true)
            {
                if (setState.IsName("RecoverState") != true)
                {
                    CheckTimer();
                    FindWeapon();
                    SetWeaponStats();
                    ReachedSender();
                    CheckEnemies();
                    CheckRecover();
                }
            }
        }
        
    }

    private void ChangeStates(string nextState)
    {
        TurnOffVariables();
        //setting next state
        AnimatorStateInfo setState = animator.GetCurrentAnimatorStateInfo(0);
        if (setState.IsName(nextState) != true)
        {
            animator.Play(nextState);
        }
        else
        {
            return;
        }

    }

    //States and checks

    private void FindWeapon()
    {
        if (data.heldWeapon == null)
        {
            if (data.weapons.Count != 0)
            {
                if (timer <= 0 && masterChecked < 2)
                {
                    //find the optimal weapon
                    MasterWeapon();
                }

                if (masterWeapon == true)
                {
                    //set the optimal weapon
                    masterChecked = 0;
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    ChangeStates("GrabWeapon");

                }

                if (masterChecked >= 2)
                {
                    //set a weapon
                    data.chosenWeapon = data.weapons[0];
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    ChangeStates("GrabWeapon");
                }

            }
        }
        else if (data.chosenEnemy != null)
        {
            if (data.heldWeapon != null && data.enemies != null && data.enemies.Count > 0)
            {
                //if has a weapon and there are enemies attack
                Attack();
            }
            else
            {
                //if does not have a weapon and there are enemies runaway
                RunAway();
            }

        }
        else
        {
            if (once == false)
            {
                //if there are no enemies group up
                GroupUp();
            }
        }

    }
    private void Attack()
    {
        CheckHighestDamage();
        ChangeStates("GoToEnemy");
    }
    private void RunAway()
    {
        ChangeStates("RunAway");
    }

    private void CheckRecover()
    {
        //if the health is below a value then recover
        var c = data.gameObject.GetComponent<HealthSystem>().health;
        if (c < 30 && canRecover == true)
        {
            animator.SetBool("Recover", true);
            animator.Play("RecoverState");
            canRecover = false;
        }
        //reset when the character can recover again
        if (c > data.gameObject.GetComponent<HealthSystem>().healthMax - 10)
        {
            canRecover = true;
        }
    }

    private void ReachedSender()
    {
        //set so once the character has been joined by group members or the character has joined its group members the character will go to the statue
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("GroupUpSender") == true || currentState.IsName("GroupUpReciever") == true)
        {
            if (data.signalSender != null)
            {
                thedist = Vector3.Distance(gameObject.transform.position, data.signalSender.transform.position);
                if (thedist < 5)
                {
                    canGroupUp = false;
                    if (currentState.IsName("AttackLocationState") != true)
                    {
                        ChangeStates("GoToStatue");
                    }
                    data.signalSender = null;
                }
            }
            
        }
       
        
    }

    private void CheckEnemies()
    {
        //check if the enemy is still in range
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("GoToEnemy") == true)
        {
            if (data.enemies.Count != 0)
            {
                if (!data.enemies.Contains(data.chosenEnemy))
                {
                    data.chosenEnemy = null;
                    if (currentState.IsName("AttackLocationState") != true)
                    {
                        ChangeStates("GoToStatue");
                    }
                }
            }
            else
            {
                data.chosenEnemy = null;
                if (currentState.IsName("AttackLocationState") != true)
                {
                    ChangeStates("GoToStatue");
                }
            }
        }
        //check if the enemy is still in range
        if (currentState.IsName("Fight") == true)
        {
            if (data.enemies.Count != 0)
            {
                if (!data.enemies.Contains(data.chosenEnemy))
                {
                    data.chosenEnemy = null;
                    if (currentState.IsName("AttackLocationState") != true)
                    {
                        ChangeStates("GoToStatue");
                    }
                }
            }
            else
            {
                data.chosenEnemy = null;
                if (currentState.IsName("AttackLocationState") != true)
                {
                    ChangeStates("GoToStatue");
                }
            }
            if (data.chosenEnemy != null)
            {
                thedist = Vector3.Distance(gameObject.transform.position, data.chosenEnemy.transform.position);
                if (thedist > 1)
                {
                    ChangeStates("GoToEnemy");
                }
            }
            
        }
        
    }

    

    private void GroupUp()
    {
        if (data.enemies.Count != 0)
        {
            if (data.heldWeapon != null && data.enemies != null && data.enemies.Count > 0)
            {
                //if the character has a weapon and there are enemies
                Attack();
            }
               
        }
        else
        {
            if (canGroupUp == true)
            {
                if (data.signalSender == null)
                {
                    if (data.heldWeapon != null)
                    {
                        //if no group member has sent a groupup signal then this character will send the signal
                        ChangeStates("GroupUpSender");
                    }

                }
                else
                {
                    if (data.heldWeapon != null)
                    {
                        //if a group member has already sent the signal then this character will recieve the signal and join them
                        ChangeStates("GroupUpReciever");
                    }
                }
            }
            
                
        }
    }

    private void MasterWeapon()
    {
        //check if the weapon is the weapon wanted
        var l = 0;
        List<GameObject> possibleWeapon = new List<GameObject>();
        foreach (GameObject weapon in data.weapons)
        {
            if (weapon != null)
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
            
        }
        //if the weapon is not optimal then add to the masterChecked (if masterChecked reaches 2 then character will choose this weapon or the next weapon)
        if (l == 0)
        {
            masterChecked = masterChecked + 1;
            timer = 3f;
        }
        // if the weapon is optimal then set it as the weapon to be picked up
        if (l >= 1)
        {
            data.chosenWeapon = possibleWeapon[0];
            masterWeapon = true;
        }
    }

    private void CheckHighestDamage()
    {
        //go through each enemy and check which enemy has the weapon with the highest damage
        var l = 0;
        List<GameObject> possibleEnemies = new List<GameObject>();
        foreach (GameObject enemy in data.enemies)
        {
            if (enemy != null)
            {
                if (enemy.GetComponent<AIData>())
                {
                    var a = enemy.GetComponent<AIData>();
                    if (a != null)
                    {
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
                }
            }
            
            
        }
        //if there was no enemy found choose an enemy from the currently in zone enemies
        if (l == 0)
        {
            data.chosenEnemy = data.enemies[0];
        }
        //if there was an enemy found set it as the enemy to attack
        if (l >= 1)
        {
            data.chosenEnemy = possibleEnemies[0];
        }
    }

    private void SetWeaponStats()
    {
        //check if the character does not have a weapon
        if (data.heldWeapon == null && weaponActive == true && weaponSet == true)
        {
            weaponActive = false;
        }
        //check has a weapon
        if (data.heldWeapon != null && weaponActive == false)
        {
            weaponSet = false;
            weaponActive = true;
        }
        //if the character does have a weapon apply stat changes
        if (weaponActive == true && weaponSet == false)
        {
            data.heldWeapon.GetComponent<WeaponStats>().SwingRate = data.heldWeapon.GetComponent<WeaponStats>().SwingRate / 2;
            weaponSet = true;
        }
    }

    private void CheckTimer()
    {
        //reduce the timer for the next time the character can check for a weapon
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void TurnOffVariables()
    {
        //reset variables
        masterWeapon = false;
    }
}
