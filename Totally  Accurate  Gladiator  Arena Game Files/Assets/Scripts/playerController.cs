using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject character; 
    public Animator animator;
    public bool dead;
    public bool hit;
    public bool hitting;
    bool hitted;
    bool moving;
    public float speed;
    public float strafeSpeed;
    public float rotationSpeed;
    ConfigurableJoint hipjoint;

    Rigidbody hips;
    public bool isGrounded;

    IEnumerator attack()
    {
        if (hitted == false) {
            hit = true;
            hitted = true;
            yield return new WaitForSeconds(0.25f);
            hit = false;
            yield return new WaitForSeconds(0.5f);
            hitted = false;
        }
    }

    void Start()
    {
        hips = character.GetComponent<Rigidbody>();
        hipjoint = character.GetComponent<ConfigurableJoint>();
    }
    
    private void move_forward()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hips.AddForce(hips.transform.forward * speed);
    }

    void move_backward()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hips.AddForce(-hips.transform.forward * speed);
    }

    void move_left()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hips.AddForce(-hips.transform.right * strafeSpeed);
    }

    void move_right()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hips.AddForce(hips.transform.right * strafeSpeed);
    }

    void rotate_right()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hipjoint.targetRotation = Quaternion.Euler(0, hipjoint.targetRotation.eulerAngles.y - rotationSpeed, 0);
    }

    void rotate_left()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hipjoint.targetRotation = Quaternion.Euler(0, hipjoint.targetRotation.eulerAngles.y + rotationSpeed, 0);
    }

    private void FixedUpdate()
    {
        moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            move_forward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            move_backward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            move_left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            move_right();
        }
        if (hitting == true)
        {
            StartCoroutine(attack());
        }
        if (moving == false)
        {
            animator.SetBool("Is_Walk", false);
        }
    }
}
