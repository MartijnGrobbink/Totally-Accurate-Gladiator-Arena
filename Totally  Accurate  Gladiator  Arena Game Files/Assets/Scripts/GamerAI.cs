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
        data = gameObject.GetComponent<AIData>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state) {
            case State.SearchWeapon:
                animator.Play(state.ToString());

                // while on searchWeapon state, check for the closest weapon to the gamer with euclidean distance
                if(data.heldWeapon == null & data.weapons.Count != 0){
                    GameObject closestWeapon = data.weapons[0];

                    foreach(GameObject weapon in data.weapons){
                        if(Vector3.Distance(weapon.transform.position, transform.position) < Vector3.Distance(closestWeapon.transform.position, transform.position) )
                            closestWeapon = weapon;
                    }

                    // when the closestWeapon has been detected, change to state GrabWeapon 
                    data.chosenWeapon = closestWeapon;
                    state = State.GrabWeapon;
                    break;
                }
                break;

            case State.GrabWeapon:
                animator.Play(state.ToString());

                // when the gamer finally grabs a weapon
                if(data.heldWeapon != null) {
                    // if no other teammate sent a groupUp, send one yourself
                    if (data.signalSender == null) 
                        state = State.GroupUpSender;

                    // if there's already a group up request, change to state GroupUpReciever 
                    else 
                        state = State.GroupUpReciever;
                    
                    break;
                } 
                
                break;

            case State.GoToEnemy:
                var healthThreshold = 30.0f; 

                // TODO if health < threshold: runaway

                // run away if the player has no weapon
                if(data.heldWeapon == null) {
                    state = State.RunAway;
                    break;
                }

                animator.Play(state.ToString());
                break;

            case State.RunAway:
                // while running again, if the gamer no longer has any enimies in his FOV
                if(data.enemies.Count == 0) {
                    // if he doesnt have a weapon, change to state Search Weapon
                    if (data.heldWeapon == null) {
                        state = State.SearchWeapon;
                        break;
                    }
                    
                    // else if no other teammate sent a group up signal, request GroupUp 
                    else if (data.signalSender == null) {
                        state = State.GroupUpSender;
                        break;
                    }
                }

                animator.Play(state.ToString());
                break;

            case State.GroupUpReciever:
                // the player will not join the others in case of receiving a GroupUp IF he does not yet have a weapon
                // therefore he will go back a the SearchWeapon state 
                if (data.heldWeapon == null) {
                    state = State.SearchWeapon;
                    break;
                } 

                // if (data.ally.Count < ) {

                // }

                animator.Play(state.ToString());
                break;

            case State.GroupUpSender:
                // nerd gamer 1: signalSender
                // nerd gamer 2: heldWeapon == null
                // nerd gamer 3: heldWeapon != null
                animator.Play(state.ToString());

                if (data.heldWeapon == null) {
                    state = State.SearchWeapon;
                    break;
                } 

                break;

            default:
                break;
        }
    }

    

}
