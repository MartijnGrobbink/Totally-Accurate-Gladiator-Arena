using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] private float distanceTimer;
    [SerializeField] private Transform handPivot;
    private NavMeshAgent agent;
    private Coroutine checkDistance;

    public GameObject weaponHeld;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void WalkToItem(GameObject weapon)
    {
        agent.SetDestination(weapon.transform.position);
        checkDistance = StartCoroutine(AIItemDistance(weapon, distanceTimer));
    }

    private IEnumerator AIItemDistance(GameObject weapon, float timer)
    {
        while(true)
        {
            yield return new WaitForSeconds(timer);

            float dist = (gameObject.transform.position - weapon.transform.position).magnitude;
            if (dist < 1f)
            {
                PickUpItem(weapon);
            }
        }
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
