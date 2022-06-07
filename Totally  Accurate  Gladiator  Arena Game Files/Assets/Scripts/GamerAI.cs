using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerAI : MonoBehaviour
{
    private static int id;
    AIData data;
    Animator animator;

    private enum State {
        RunAway, 
        GoToEnemy,
        SearchWeapon,
        GrabWeapon,
        GroupUpReciever,
        GroupUpSender,
    };

    private State state;
    
    // Awake is called before start, even if the script is disabled  
    void Awake() {
        state = State.SearchWeapon;
    }

    // Start is called before the first frame update
    void Start()
    {   
        id++;
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state) {
            case State.SearchWeapon:
                animator.Play(State.SearchWeapon.ToString());

                // check for the closest weapon to the gamer
                if(data.heldWeapon == null & data.weapons.Count != 0){
                    GameObject closestWeapon = data.weapons[0];
                    // Debug.Log(id + " closest weapon: " + closestWeapon + " " + closestWeapon.transform.position);
                    foreach(GameObject weapon in data.weapons){
                        // Debug.Log(id + "curr-gamer: " + Vector3.Distance(weapon.transform.position, transform.position) +  "\n closest-gamer: " + Vector3.Distance(closestWeapon.transform.position, transform.position));
                        if(Vector3.Distance(weapon.transform.position, transform.position) < Vector3.Distance(closestWeapon.transform.position, transform.position) )
                            closestWeapon = weapon;
                    }
                    data.chosenWeapon = closestWeapon;
                    Debug.Log(closestWeapon);
                    state = State.GrabWeapon;
                }
                break;
            case State.GrabWeapon:
                // Debug.Log("Grab Weapon");
                animator.Play(State.GrabWeapon.ToString());
                if(data.heldWeapon != null){
                    state = State.GoToEnemy;
                }
                break;
            case State.GoToEnemy:
                // Debug.Log("go to enemy");
                break;
            case State.RunAway:
                break;
            case State.GroupUpReciever:
                break;
            case State.GroupUpSender:
                break;
            default:
                break;
        }
    }

    

}
