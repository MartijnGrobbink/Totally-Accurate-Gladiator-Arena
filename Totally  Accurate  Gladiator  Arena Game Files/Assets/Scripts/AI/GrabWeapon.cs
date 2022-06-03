using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabWeapon : WalkToPosition
{
    [SerializeField] private float distanceTimer;
    [SerializeField] private Transform handPivot;
    private NavMeshAgent agent;
    private GameObject targetWeapon;
    private AIData data;

    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void WalkToItem(GameObject weapon)
    {
        base.Walk(agent, weapon.transform);
        targetWeapon = weapon;
    }

    protected override void InRangeOfPosition()
    {
        base.InRangeOfPosition();
        PickUpItem(targetWeapon);
    }
    private void PickUpItem(GameObject weapon)
    {
        Rigidbody rigidBody = weapon.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;

        weapon.transform.SetParent(handPivot, false);
        weapon.transform.SetPositionAndRotation(handPivot.position, handPivot.rotation);

        data.heldWeapon = weapon;
        weapon.layer = 0;
        Debug.Log("reached weapon grab distance");
    }

    public void DropItem()
    {
        data.heldWeapon.layer = 6;
        data.heldWeapon.transform.SetParent(null, true);

        Rigidbody rigidBody = data.heldWeapon.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;
        rigidBody.constraints = RigidbodyConstraints.None;

        data.heldWeapon = null;
    }
}
