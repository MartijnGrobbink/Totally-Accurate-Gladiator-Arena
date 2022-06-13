using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIController : MonoBehaviour
{
    AIData data;
    Animator animator;
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
        //if (currentState.IsName(enterStateName) != true)
        //{
            Debug.Log(currentState);
            animator.Play(enterStateName);
       // }
    }

    private void AttackState()
    {
        if(data.chosenEnemy != null)
        {
            if(data.ally.Count != 0)
                for (int i = 0; i < data.ally.Count; i++)
                {
                    AIData allyData = data.ally[i].GetComponent<AIData>();
                    if (allyData.chosenEnemy != null)
                        data.chosenEnemy = allyData.chosenEnemy;
                }
            else
                data.chosenEnemy = data.enemies[0];
        }
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
            Debug.Log("Test");
            if (data.weapons.Count !=  0)
            {
                data.chosenWeapon = data.weapons[0];
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
            else
                SwitchStates("GroupUpReciever");
        }
    }
}
