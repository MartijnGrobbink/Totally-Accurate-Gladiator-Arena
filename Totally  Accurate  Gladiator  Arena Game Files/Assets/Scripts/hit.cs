using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public GameObject character;
    public playerController playerController;
    ConfigurableJoint cj;
    ConfigurableJoint cjtemp;
    Quaternion rotation;

    void Start()
    {
        playerController = character.GetComponent<playerController>();
        cj = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        if (playerController.hit == true)
        {
            cjtemp = cj;
            rotation = cjtemp.targetRotation;
            rotation.x = -1f;
            rotation.z = -0.4f;
            cjtemp.targetRotation = rotation;
            cj = cjtemp;
        }
        else
        {
            cjtemp = cj;
            rotation = cjtemp.targetRotation;
            rotation.x = 0f;
            rotation.z = 0f;
            cjtemp.targetRotation = rotation;
            cj = cjtemp;
        }
    }
}
