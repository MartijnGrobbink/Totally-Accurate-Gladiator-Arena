using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Romans : MonoBehaviour
{
    AIData data;
    Animator animator;

    private enum State
    {
        RunAway,
        GoToEnemy,
        SearchWeapon,
        GrabWeapon,
        GroupUpReciever,
        GroupUpSender,
    };

    private State state;

    // Awake is called before start, even if the script is disabled  
    void Awake()
    {
        state = State.SearchWeapon;
    }

    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.SearchWeapon)
        {
            SearchWeaponState();
        }
        else if (state == State.GrabWeapon)
        {
            GrabWeaponState();
        }
        else if (state == State.GoToEnemy)
        {
            GoToEnemyState();
        }
        else if (state == State.RunAway)
        {
            RunAwayState();
        }
        else if (state == State.GroupUpReciever)
        {
            GroupUpRecieverState();
        }
        else if (state == State.GroupUpSender)
        {
            GroupUpSenderState();
        }
    }

    private void SearchWeaponState()
    {
        if (data.heldWeapon == null & data.weapons.Count > 0)
        {
            data.chosenWeapon = GetClosestWeapon();

            if (data.chosenWeapon.GetComponent<WeaponStats>().Wielder == null)
                state = State.GrabWeapon;
            else
                state = State.RunAway;
        }

        animator.Play(state.ToString());
    }

    public GameObject GetClosestWeapon()
    {
        GameObject closestWeapon = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        int counter = 0;

        foreach (GameObject weapon in data.weapons)
        {
            Vector3 diff = weapon.transform.position - position;
            float curDistance = Vector3.Distance(weapon.transform.position, position);

            if (curDistance < distance)
            {
                if(weapon.GetComponent<WeaponStats>().Wielder == null)
                {
                    // Set new closest weapon
                    closestWeapon = weapon;
                    distance = curDistance;
                }
            }
            counter++;
        }

        return closestWeapon;
    }

    private void GrabWeaponState()
    {
        // when the player finally grabs a weapon
        if (data.heldWeapon != null)
        {
            if (data.enemies.Count > 0)
            {
                data.chosenEnemy = GetClosestEnemy();
                if (data.chosenWeapon != null)
                {
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                }
                state = State.GoToEnemy;
            }
            else
            {
                if (data.signalSender == null)
                    state = State.GroupUpSender;

                else
                    state = State.GroupUpReciever;
            }
        }
        else if (data.chosenWeapon != null)
        {
            if (data.chosenWeapon.GetComponent<WeaponStats>().Wielder != null)
            {
                data.chosenWeapon = GetClosestWeapon();
                if (data.chosenWeapon != null)
                {
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                }
            }
            data.weapons.Clear();
            try
            {
                GetComponent<GrabWeapon>().WalkToItem(data.chosenWeapon);
            }
            catch(System.Exception e) { }
        }
        else if (data.chosenWeapon == null)
        {
            data.chosenWeapon = GetClosestWeapon();
            if (data.chosenWeapon != null)
            {
                Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
            }
        }

        animator.Play(state.ToString());
    }

    private GameObject GetClosestEnemy()
    {
        GameObject closestEnemy = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        int counter = 0;

        foreach (GameObject enemy in data.enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = Vector3.Distance(enemy.transform.position, position);

            if (curDistance < distance)
            {
                // Set new closest secret
                closestEnemy = enemy;
                distance = curDistance;
            }
            counter++;
        }

        return closestEnemy;
    }

    private void GoToEnemyState()
    {
        // run away if the player doesn't have a weapon
        if (data.heldWeapon == null)
        {
            state = State.RunAway;
        }
        else
        {
            if (data.chosenEnemy != null)
            {
                data.lastDestination = data.chosenEnemy.transform;
            }
            else
            {
                data.chosenEnemy = GetClosestEnemy();
            }
        }

        if (!animator.GetBool("Combat"))
        {
            animator.Play(state.ToString());
        }

    }

    private void RunAwayState()
    {
        if (data.enemies.Count == 0)
        {
            if (data.heldWeapon == null)
            {
                state = State.SearchWeapon;
            }

            else if (data.signalSender == null)
            {
                state = State.GroupUpSender;
            }
        }

        animator.Play(state.ToString());
    }

    private void GroupUpRecieverState()
    {
        if (data.heldWeapon == null)
        {
            state = State.SearchWeapon;
        }

        animator.Play(state.ToString());
    }

    private void GroupUpSenderState()
    {
        if (data.heldWeapon == null)
        {
            state = State.SearchWeapon;
        }
        else
        {
            animator.SetBool("AttackStatue", true);
        }
        if(!animator.GetBool("AttackStatue"))
            animator.Play(state.ToString());
    }
}
