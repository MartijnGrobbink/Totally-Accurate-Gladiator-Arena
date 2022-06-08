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

                    // distance between points
                    // TODO change to find the closest weapon through the available paths and not euclidean distance
                    foreach(GameObject weapon in data.weapons){
                        if(Vector3.Distance(weapon.transform.position, transform.position) < Vector3.Distance(closestWeapon.transform.position, transform.position) )
                            closestWeapon = weapon;
                    }
                    data.chosenWeapon = closestWeapon;
                    state = State.GrabWeapon;
                }
                break;

            case State.GrabWeapon:
                animator.Play(state.ToString());
                if(data.heldWeapon != null){
                    state = State.GroupUpSender;
                }
                break;

            case State.GoToEnemy:
                animator.Play(state.ToString());
                // TODO if health < threshold: runaway

                // run away if the player has no weapon
                if(data.heldWeapon == null) {
                    state = State.RunAway;
                }
                break;

            case State.RunAway:
                animator.Play(state.ToString());
                break;

            case State.GroupUpReciever:
                // the player will not join the others in case of receiving a GroupUp IF he does not yet have a weapon
                // therefore he will go back a the SearchWeapon state 
                if(data.heldWeapon == null){
                    state = State.SearchWeapon;
                    break;
                } 

                animator.Play(state.ToString());
                break;

            case State.GroupUpSender:
                animator.Play(state.ToString());
                break;

            default:
                break;
        }
    }

    

}
