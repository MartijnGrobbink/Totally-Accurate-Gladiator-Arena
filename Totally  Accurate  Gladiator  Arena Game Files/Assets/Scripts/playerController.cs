using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject character;
    public GameObject Rotation;
    public Animator animator;
    public ParticleSystem particles;
    AudioSource audioData;
    public bool dead;
    public bool hit;
    public bool hitting;
    bool hitted;
    public bool stun = false;
    public bool moving;
    public float speed;
    public float rotationSpeed;
    ConfigurableJoint hipjoint;
    float old_rotation;

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
        audioData = character.GetComponent<AudioSource>();
        old_rotation = Rotation.transform.rotation.eulerAngles.y;
        hips = character.GetComponent<Rigidbody>();
        hipjoint = character.GetComponent<ConfigurableJoint>();
    }

    public void move_forward()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
    }

    void move_backward()
    {
        animator.SetBool("Is_Walk", true);
        moving = true;
        hips.AddForce(-hips.transform.forward * speed);
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
        character.transform.position = Rotation.transform.position;
        hipjoint.targetRotation = Quaternion.Euler(Rotation.transform.rotation.eulerAngles.x, -Rotation.transform.rotation.eulerAngles.y-90, Rotation.transform.rotation.eulerAngles.z);
        if (hitting == true)
        {
            StartCoroutine(attack());
        }
        if (stun == true)
            particles.Play();
        else {
            particles.Stop();
        }
        if (moving == true && !audioData.isPlaying)
            audioData.Play(0);
        if (moving == false)
        {
            audioData.Stop();
            animator.SetBool("Is_Walk", false);
        }
    }
}
