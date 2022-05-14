using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabWeapon : WalkToPosition
{
    [SerializeField] private Transform handPivot;
    public GameObject weaponHeld;

    private NavMeshAgent agent;
    private GameObject chosenWeapon;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void WalkToItem(GameObject weapon)
    {
        chosenWeapon = weapon;
        base.Walk(agent, weapon.transform);
    }
    
    protected override void InRangeOfPosition()
    {
        base.InRangeOfPosition();
        PickUpItem(chosenWeapon);
    }

    private void PickUpItem(GameObject weapon)
    {
        weapon.transform.SetParent(handPivot, false);
        weapon.transform.SetPositionAndRotation(handPivot.position, handPivot.rotation);

        Rigidbody rigidBody = weapon.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        weaponHeld = weapon;
        Debug.Log("reached weapon grab distance");
    }

    public void DropItem()
    {
        weaponHeld.transform.SetParent(null, true);

        Rigidbody rigidBody = weaponHeld.GetComponent<Rigidbody>();
        rigidBody.useGravity = true;

        weaponHeld = null;
    }
}
