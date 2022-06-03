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
        weapon.transform.SetParent(handPivot, false);
        weapon.transform.SetPositionAndRotation(handPivot.position, handPivot.rotation);

        Rigidbody rigidBody = weapon.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        data.heldWeapon = weapon;
        weapon.tag = "Untagged";
        Debug.Log("reached weapon grab distance");
    }

    public void DropItem()
    {
        data.heldWeapon.tag = "Weapon";
        data.heldWeapon.transform.SetParent(null, true);

        Rigidbody rigidBody = data.heldWeapon.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;

        data.heldWeapon = null;
    }
}
