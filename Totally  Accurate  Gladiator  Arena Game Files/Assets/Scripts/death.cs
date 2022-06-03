using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public GameObject character;
    playerController playerController;
    JointDrive drive;
    ConfigurableJoint cjtemp;
    ConfigurableJoint cj;

    void Start()
    {
        playerController = character.GetComponent<playerController>();
        cj = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        if (playerController.dead == true)
        {
            cjtemp = cj;
            drive = cjtemp.angularXDrive;
            drive.positionSpring = 2;
            cjtemp.angularXDrive = drive;
            cjtemp.angularYZDrive = drive;
            cj = cjtemp;
        }
    }
}
