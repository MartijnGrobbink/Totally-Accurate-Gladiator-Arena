using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueManager : MonoBehaviour
{
    public float radius;
    public Transform destination;
    public NavMeshAgent agent;
    public Animator animator;

    private WalkToPosition movement;

    [SerializeField] private LayerMask targetMask;

    public List<GameObject> inRange;

    private static bool BeingContested = false;

    private AudioSource source;
    private bool mPlaying = false;

    private void Start()
    {
        movement = gameObject.GetComponent<WalkToPosition>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckInRange();
        if (inRange.Count != 0)
        {
            CheckTagsInRange();
        }
        CheckIfDestinationValid();
    }
    //-------------------------------------------------------------Range Detection-------------------------------------------------------
    private void CheckInRange()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            if (inRange.Contains(rangeChecks[i].gameObject) != true && rangeChecks[i].gameObject != gameObject && rangeChecks[i].CompareTag("Weapon") != true)
                inRange.Add(rangeChecks[i].gameObject);
        }
        CheckIfStillInRange();
    }

    private void CheckIfStillInRange()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            float dist = (gameObject.transform.position - inRange[i].transform.position).magnitude;
            if (dist > radius)
            {
                inRange.Remove(inRange[i].gameObject);
            }
        }
    }
    //--------------------------------------------------------------Contested Check------------------------------------------------------
    private void CheckTagsInRange()
    {
        string firstTag = inRange[0].tag;

        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i].tag != firstTag)
            {
                Contested();
                return;
            }
            if (i == inRange.Count - 1)
            {
                NotContested();
            }
        }
    }

    private void Contested()
    {
        movement.StopWalking(agent);
        setBeingContested(true);
    }

    private void NotContested()
    {
        UI_EventsManager.current.TeamActive("NoTeam");
        AIData contestantData = inRange[0].GetComponent<AIData>();
        if (contestantData != null)
        {
            MoveToBase();
            setBeingContested(false);

        }
        else
        {
            Debug.LogError("No AIdata found");
        }
    }

//-------------------------------------------For the camera--------------------------------------------------------------------------

    public bool getBeingContested ()
    {
        return BeingContested;
    }

    public void setBeingContested(bool newValue)
    {
        UI_EventsManager.current.TeamActive("Contested");
        BeingContested = newValue;
    }

//--------------------------------------------------------------------Movement-------------------------------------------------------
    private void MoveToBase()
    {
        AIData contestantData = inRange[0].GetComponent<AIData>();
        UI_EventsManager.current.TeamActive(inRange[0].GetComponent<AIData>().TeamName);
        destination = contestantData.teamBase;
        movement.Walk(agent, destination);
    }
//-------------------------------------------------------Check if destination still valid--------------------------------------------
    private void CheckIfDestinationValid()
    {
        if (inRange.Count != 0)
        {
            AIData contestantData = inRange[0].GetComponent<AIData>();
            if (destination != contestantData.teamBase)
            {
                destination = contestantData.teamBase;
                movement.Walk(agent, destination);
            }
        }

        else
        {
            movement.StopWalking(agent);
        }
    }
//-------------------------------------------------------------------Output----------------------------------------------------------
    public void AtBase()
    {
        Teams_EventManager.current.StatueCaptures(inRange[0].GetComponent<AIData>().TeamName);
        Destroy(gameObject);
    }

 //-------------------------------------------------------------------Animation----------------------------------------------------------
    public void MoveAnimate()
    {
        animator.SetBool("Move", true);
        if (mPlaying == false)
        {
            source.Play();
            mPlaying = true;
        }
    }

    public void DontMoveAnimate()
    {
        animator.SetBool("Move", false);
        if (mPlaying == true)
        {
            source.Stop();
            mPlaying = false;
        }
    }

    public void CheckAnim()
    {
        if (agent.hasPath == true)
        {
            MoveAnimate();
        }

        if (agent.hasPath == false)
        {
            DontMoveAnimate();
        }
    }
}
