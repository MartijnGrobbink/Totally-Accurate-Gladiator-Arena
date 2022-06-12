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
    private bool canAttackLoc;
    private bool canRecover;

    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
        healthsystem = gameObject.GetComponent<HealthSystem>();
        healthsystem.healthMax = 75;
        canGroupUp = true;
        canAttackLoc = true;
        canRecover = true;
    }

    void Update()
    {
        //Added
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Effects") != true)
        {
            if (currentState.IsName("AttackLocationState") != true)
            {
                if (currentState.IsName("RecoverState") != true)
                {
                    CheckTimer();
                    GettingWeaponState();
                    SetWeaponStats();
                    ReachedSender();
                    CheckEnemies();
                    SetAttackLocation();
                    CheckRecover();
                }
            }
        }
        
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

    private void CheckRecover()
    {
        var c = data.gameObject.GetComponent<HealthSystem>().health;
        if (c < 30 && canRecover == true)
        {
            animator.SetBool("Recover", true);
            animator.Play("RecoverState");
            canRecover = false;
        }

        if (c > data.gameObject.GetComponent<HealthSystem>().healthMax - 10)
        {
            canRecover = true;
        }
    }

    private void SetAttackLocation()
    {
        /*
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("GoToStatue") == true && canAttackLoc == true)
        {
            animator.SetBool("AttackLoc", true);
            animator.Play("AttackLocationState");
            canAttackLoc = false;
        }
        */
    }

    private void ReachedSender()
    {
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
                        SwitchStates("GoToStatue");
                    }
                    data.signalSender = null;
                }
            }
            
        }
       
        
    }

    private void CheckEnemies()
    {
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
                        SwitchStates("GoToStatue");
                    }
                }
            }
            else
            {
                data.chosenEnemy = null;
                if (currentState.IsName("AttackLocationState") != true)
                {
                    SwitchStates("GoToStatue");
                }
            }
        }

        if (currentState.IsName("Fight") == true)
        {
            if (data.enemies.Count != 0)
            {
                if (!data.enemies.Contains(data.chosenEnemy))
                {
                    data.chosenEnemy = null;
                    if (currentState.IsName("AttackLocationState") != true)
                    {
                        SwitchStates("GoToStatue");
                    }
                }
            }
            else
            {
                data.chosenEnemy = null;
                if (currentState.IsName("AttackLocationState") != true)
                {
                    SwitchStates("GoToStatue");
                }
            }
            if (data.chosenEnemy != null)
            {
                thedist = Vector3.Distance(gameObject.transform.position, data.chosenEnemy.transform.position);
                if (thedist > 1)
                {
                    SwitchStates("GoToEnemy");
                }
            }
            
        }
        
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
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    SwitchStates("GrabWeapon");
                    
                }

                if (masterChecked >= 2)
                {
                    data.chosenWeapon = data.weapons[0];
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    SwitchStates("GrabWeapon");
                }
                
            }
        }
        else if (data.chosenEnemy != null)
        {
            if (data.heldWeapon != null && data.enemies != null && data.enemies.Count > 0)
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
            if (once == false)
            {
                GroupUpState();
            }
        }
           
    }

    private void GroupUpState()
    {
        if (data.enemies.Count != 0)
        {
            if (data.heldWeapon != null && data.enemies != null && data.enemies.Count > 0)
            {
                AttackState();
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
                        SwitchStates("GroupUpSender");
                    }

                }
                else
                {
                    if (data.heldWeapon != null)
                    {
                        SwitchStates("GroupUpReciever");
                    }
                }
            }
            
                
        }
    }

    private void MasterWeapon()
    {
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
