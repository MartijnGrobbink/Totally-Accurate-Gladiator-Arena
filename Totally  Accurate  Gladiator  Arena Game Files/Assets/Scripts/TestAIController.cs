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
        if (data.weapons.Count > 0 && data.heldWeapon == null)
        {
            data.chosenWeapon = data.weapons[0];
            animator.SetInteger("State", 3);
        }
        else
            data.chosenWeapon = null;

        if (data.signalSender == null && data.heldWeapon != null && animator.GetInteger("State") == 3)
        {
            animator.SetInteger("State", 4);
        }
        else if (data.heldWeapon != null && animator.GetInteger("State") == 3)
            animator.SetInteger("State", 5);
    }
}
