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
        GoToStatue,
    };

    private State state;
    private int healthThreshold = 30;
    
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
                if (data.heldWeapon == null & data.weapons.Count != 0){
                    GameObject closestWeapon = data.weapons[0];

                    foreach (GameObject weapon in data.weapons){
                        if(Vector3.Distance(weapon.transform.position, transform.position) < Vector3.Distance(closestWeapon.transform.position, transform.position) )
                            closestWeapon = weapon;
                    }

                    // when the closestWeapon has been detected, choose it and change to state GrabWeapon 
                    data.chosenWeapon = closestWeapon;
                    Teams_EventManager.current.WeaponUsed(data.TeamName, data.MemberName, data.chosenWeapon.GetComponent<WeaponStats>().DesiredTag);
                    state = State.GrabWeapon;
                    break;
                }
                //Debug.Log(state.ToString());
                break;

            case State.GrabWeapon:
                animator.Play(state.ToString());

                // when the gamer finally grabs a weapon
                if (data.heldWeapon != null) {
                    // if no other teammate sent a groupUp, send one yourself
                    if (data.signalSender == null) 
                        state = State.GroupUpSender;

                    // if there's already a group up request, change to state GroupUpReciever 
                    else 
                        state = State.GroupUpReciever;
                    
                    break;
                } 
                
                //Debug.Log(state.ToString());
                break;

            case State.GoToEnemy:
                // gamer's health 
                var health = data.gameObject.GetComponent<HealthSystem>().health;
                
                // run away if the player has no weapon or health critical (below threshold)
                if (data.heldWeapon == null | health <= healthThreshold) {
                    state = State.RunAway;
                    break;
                }

                // if there are no enemies on the FOV, go to statue, get those points
                if (data.enemies.Count == 0) {
                    state = State.GoToStatue;
                    break;
                }

                // if there's yet no chosenEnemy
                if (data.chosenEnemy == null) {
                    foreach (GameObject enemy in data.enemies) {
                        var enemyData = enemy.GetComponent<AIData>();
                        var enemyHealth = enemy.gameObject.GetComponent<HealthSystem>().health;

                        // if any enemy in the FOV doesn't have a weapon, choose them immediately as enemy and attack
                        if (enemyData.heldWeapon == null) {
                            data.chosenEnemy = enemy;
                            break;

                        // otherwise, choose an enemy that has a health lower than ours, smort
                        } else if (enemyHealth < health) {
                            data.chosenEnemy = enemy;

                        // if none of those cases are true, simply pick the last enemy on data.enemies
                        } else {
                            data.chosenEnemy = enemy;
                        }
                    }
                } 

                animator.Play(state.ToString());
                //Debug.Log(state.ToString());
                break;

            case State.RunAway:
                // while running away, when the gamer no longer has any enemies in his FOV
                if (data.enemies.Count == 0) {
                    // if he doesnt have a weapon, change to state Search Weapon
                    if (data.heldWeapon == null) {
                        state = State.SearchWeapon;
                        break;
                    } else {
                        if (data.signalSender == null) {
                            state = State.GroupUpSender;
                            break;
                        } else {
                            state = State.GroupUpReciever;
                            break;
                        }
                    }
                }

                animator.Play(state.ToString());
                //Debug.Log(state.ToString());
                break;

            case State.GroupUpReciever:
                // the player will not join the others in case of receiving a GroupUp IF he does not yet have a weapon
                // therefore he will go back a the SearchWeapon state 
                if (data.heldWeapon == null) {
                    state = State.SearchWeapon;
                    break;
                } 

                // if there are more enemies than allies, ignore them and go to statue
                if (data.enemies.Count > data.ally.Count) {
                    state = State.GoToStatue;
                    break;
                }

                animator.Play(state.ToString());
                //Debug.Log(state.ToString());
                break;

            case State.GroupUpSender:
                animator.Play(state.ToString());
                
                // if the gamer doesn't have a weapon, go search for one
                if (data.heldWeapon == null) {
                    state = State.SearchWeapon;
                    break;
                } 

                // if the gamer is nearby at least one ally, go to statue
                if (data.ally.Count >= 1) {
                    state = State.GoToStatue;
                    break;
                }

                //Debug.Log(state.ToString());
                break;

            case State.GoToStatue:
                animator.Play(state.ToString());

                // when statue reaches a base (== null), attack any nearby enemies
                if (data.statue == null && data.enemies.Count > 0) {
                    state = State.GoToEnemy;
                    break;
                }   

                //Debug.Log(state.ToString());
                break;

            default:
                break;
        }
    }
}
