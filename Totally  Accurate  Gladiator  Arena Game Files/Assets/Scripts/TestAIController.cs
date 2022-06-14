using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIController : MonoBehaviour
{
    private AIData data;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GettingWeaponState();
    }
    private void SwitchStates(string enterStateName)
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName(enterStateName) != true)
        {
            animator.Play(enterStateName);
        }
    }

    private void AttackState()
    {
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

    private void ChooseWeapon()
    {
        for (int i = 0; i < data.weapons.Count; i++)
        {
            if (data.weapons[i] != null)
            {
                if (data.chosenWeapon == null)
                {
                    WeaponStats stats = data.weapons[i].GetComponent<WeaponStats>();
                    if (gameObject.tag == stats.DesiredTag)
                        data.chosenWeapon = data.weapons[i];

                }
                else
                    return;
            }
            if(i == data.weapons.Count -1)
            {
                data.chosenWeapon = data.weapons[0];
            }
        }
    }
}
