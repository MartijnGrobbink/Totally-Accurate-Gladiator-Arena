using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabWeapon : WalkToPosition
{
    [SerializeField] private Transform handPivot;
    private GameObject targetWeapon;
    private AIData data;

    void Start()
    {
        data = gameObject.GetComponent<AIData>();
        CheckHand();
    }

    public void WalkToItem(GameObject weapon)
    {
        base.Walk(data.agent, weapon.transform);
        targetWeapon = weapon;
    }

    protected override void InRangeOfPosition()
    {
        base.InRangeOfPosition();
        PickUpItem(targetWeapon);
    }

    private void PickUpItem(GameObject weapon)
    {
        if (weapon != null)
        {
            if (data.heldWeapon != null)
                DropItem();

            Rigidbody rigidBody = weapon.GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;

            weapon.transform.SetParent(handPivot, false);
            weapon.transform.SetPositionAndRotation(handPivot.position, handPivot.rotation);

            weapon.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            data.heldWeapon = weapon;
            data.heldWeapon.GetComponent<WeaponStats>().Wielder = gameObject;
            data.chosenWeapon = null;
            weapon.layer = 0;
            Reset();
        }
    }

    private void Reset()
    {

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

    private void CheckHand()
    {
        if(data.heldWeapon != null)
        {
            if (handPivot.childCount == 0)
                Debug.LogError("Thinks has something but doesnt");
        }
    }
}
