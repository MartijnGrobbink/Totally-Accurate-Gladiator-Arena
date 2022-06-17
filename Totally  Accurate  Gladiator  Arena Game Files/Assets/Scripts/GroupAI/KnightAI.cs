using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : MonoBehaviour
{
    private AIData data;
    private Animator animator;
    private AnimatorStateInfo currentState;
    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("GoToEnemy") == true || currentState.IsName("Fight") == true || data.enemies.Count != 0)
            AttackState();
        else if (currentState.IsName("GroupUpSender") == true || currentState.IsName("GroupUpReciever") == true)
            GroupUpState();
        else if (currentState.IsName("GoToStatue") == true)
            Statue();
        else
            GettingWeaponState();

    }
    private void SwitchStates(string enterStateName)
    {
        if (currentState.IsName(enterStateName) != true)
        {
            animator.Play(enterStateName);
        }
    }

    private void AttackState()
    {
        if (data.enemies.Contains(data.chosenEnemy) != true)
            data.chosenEnemy = null;

        if (data.chosenEnemy != null)
        {
            if (data.ally.Count != 0)
                for (int i = 0; i < data.ally.Count; i++)
                {
                    AIData allyData = data.ally[i].GetComponent<AIData>();
                    if (allyData.chosenEnemy != null)
                    {
                        data.chosenEnemy = allyData.chosenEnemy;
                        SwitchStates("GoToEnemy");
                    }
                }
            else
            {
                data.chosenEnemy = data.enemies[0];
                SwitchStates("GoToEnemy");
            }
        }
        if (data.chosenEnemy == null)
            SwitchStates("GoToStatue");

        if (data.heldWeapon == null)
            SwitchStates("GrabWeapon");
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
                ChooseWeapon();
                if (data.chosenWeapon != null)
                    SwitchStates("GrabWeapon");
            }
        }
        else if (data.chosenEnemy != null)
        {
            if (data.heldWeapon != null)
                AttackState();
            else
                RunAwayState();
        }
        else
            GroupUpState();
    }

    private void GroupUpState()
    {
        if (data.enemies.Count != 0)
            AttackState();
        else
        {
            if (data.signalSender == null)
                SwitchStates("GroupUpSender");
            else if (data.signalSender != gameObject)
                SwitchStates("GroupUpReciever");
        }
    }

    private void Statue()
    {
        if (data.heldWeapon != null)
        {
            if (data.enemies.Count != 0)
            {
                SwitchStates("GoToEnemy");
            }
        }
        else
            SwitchStates("GrabWeapon");
    }

    private void ChooseWeapon()
    {
        int mostDamage = 0;
        GameObject bestWeapon = null;
        for (int i = 0; i < data.weapons.Count; i++)
        {
            if (data.weapons[i] != null)
            {
                WeaponStats stats = data.weapons[i].GetComponent<WeaponStats>();
                if (stats.Damage > mostDamage)
                {
                    mostDamage = stats.Damage;
                    bestWeapon = data.weapons[i];
                }
                if (i == data.weapons.Count - 1)
                {
                    data.chosenWeapon = bestWeapon;
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    mostDamage = 0;
                    bestWeapon = null;
                }
            }
        }
    }
}
