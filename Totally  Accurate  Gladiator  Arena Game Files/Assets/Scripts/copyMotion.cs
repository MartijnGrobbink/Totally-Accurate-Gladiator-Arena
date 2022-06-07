using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyMotion : MonoBehaviour
{
    public Transform targetLimb;
    ConfigurableJoint cj;

    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        cj.targetRotation = Quaternion.Euler(targetLimb.transform.rotation.eulerAngles.x, cj.targetRotation.y, targetLimb.transform.rotation.eulerAngles.z);
    }
}
