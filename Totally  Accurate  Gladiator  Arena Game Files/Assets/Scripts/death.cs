using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public playerController playerController;
    JointDrive drive;
    ConfigurableJoint cjtemp;
    ConfigurableJoint cj;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<playerController>().GetComponent<playerController>();
        cj = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        if (playerController.dead == true)
        {
            cjtemp = cj;
            drive = cjtemp.angularXDrive;
            drive.positionSpring = 3;
            cjtemp.angularXDrive = drive;
            cjtemp.angularYZDrive = drive;
            cj = cjtemp;
        }
    }
}
