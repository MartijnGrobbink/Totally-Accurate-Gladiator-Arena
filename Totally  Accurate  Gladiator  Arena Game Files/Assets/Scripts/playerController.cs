using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator animator;
    public bool dead;
    bool moving;
    public float speed;
    public float strafeSpeed;

    public Rigidbody hips;
    public bool isGrounded;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
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

    void idle()
    {
        animator.SetBool("Is_Walk", false);
    }

    private void FixedUpdate()
    {
        moving = false;
        if (isGrounded == true) {
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
        }
        if (moving == false)
        {
            animator.SetBool("Is_Walk", false);
        }
    }
}
