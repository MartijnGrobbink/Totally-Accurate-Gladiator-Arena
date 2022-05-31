using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabWeapon : WalkToPosition
{
    [SerializeField] private float distanceTimer;
    [SerializeField] private Transform handPivot;
    private NavMeshAgent agent;
    private Coroutine checkDistance;
    private GameObject targetWeapon;
    public GameObject weaponHeld;

    void Start()
    {
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
        StopCoroutine(checkDistance);
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
