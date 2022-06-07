using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_AI : MonoBehaviour
{
    AIData data;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        data = GetComponent<AIData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.heldWeapon == null && data.weapons.Count > 0)
        {
            data.chosenWeapon = data.weapons[0];
            animator.Play("GrabWeapon");
        }
        else if (data.enemies.Count > 0)
        {
            if (data.heldWeapon == null) {
                animator.Play("RunAway");
            }
            else
            {
                data.chosenEnemy = data.enemies[0];
                animator.Play("GoToEnemy");
            }
        }
    }
}
