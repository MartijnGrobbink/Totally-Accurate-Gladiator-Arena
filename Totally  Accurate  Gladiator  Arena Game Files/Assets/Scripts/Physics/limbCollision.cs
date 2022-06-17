using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limbCollision : MonoBehaviour
{
    public playerController playerController;

    private void Start()
    {
        playerController = GameObject.FindObjectOfType<playerController>().GetComponent<playerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isGrounded = true;
    }
}
