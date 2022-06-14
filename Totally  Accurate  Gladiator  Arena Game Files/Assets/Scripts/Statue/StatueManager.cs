using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueManager : MonoBehaviour
{
    public float radius;
    public Transform destination;
    public float thedist;
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
        //Missing audio source
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckAnim();
        CheckInRange();
        if (inRange.Count != 0)
        {
            CheckTagsInRange();
        }
        CheckIfDestinationValid();

        if (BeingContested == true)
        {
            Teams_EventManager.current.StatueStatus("Contested");
        }
        if (destination != null)
        {
            thedist = Vector3.Distance(gameObject.transform.position, destination.transform.position);
            if (thedist < 5)
            {
                AtBase();
            }
        }

    }
    //-------------------------------------------------------------Range Detection-------------------------------------------------------

    //Check if the items are in the view range
    private void CheckInRange()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        for (int i = 0; i < rangeChecks.Length; i++)
        {
            CheckForParents(rangeChecks[i].gameObject);
        }

        CleanUp();

        if (inRange.Count != 0)
            CheckIfStillInRange();
    }

    private void CheckForParents(GameObject rangeCheck)
    {
        if (rangeCheck.transform.parent == null)
        {
            if (inRange.Contains(rangeCheck.gameObject) != true && rangeCheck.gameObject.CompareTag("Weapon") != true)
                inRange.Add(rangeCheck.gameObject);
        }
        else
            CheckForParents(rangeCheck.transform.parent.gameObject);
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
    //-----------------------------------------------------------Check If Not Deleted------------------------------------------------------
    private void CleanUp()
    {
        for (int i = 0; i < inRange.Count; i++)
        {
            if (inRange[i] == null)
                inRange.RemoveAt(i);
        }
    }

    //--------------------------------------------------------------Contested Check------------------------------------------------------
    private void CheckTagsInRange()
    {
        if (inRange.Count != 0)
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

    }

    private void Contested()
    {
        movement.StopWalking(agent);
        setBeingContested(true);
    }

    private void NotContested()
    {
        Teams_EventManager.current.StatueStatus("NoTeam");
        AIData contestantData;

        if (inRange[0].transform.parent == null)
            contestantData = inRange[0].GetComponent<AIData>();
        else
            contestantData = inRange[0].GetComponent<AIData>();

        if (contestantData != null)
        {
            MoveToBase();
            setBeingContested(false);
        }
    }

    //-------------------------------------------For the camera--------------------------------------------------------------------------

    public bool getBeingContested()
    {
        return BeingContested;
    }

    public void setBeingContested(bool newValue)
    {
        BeingContested = newValue;
    }

    //--------------------------------------------------------------------Movement-------------------------------------------------------
    private void MoveToBase()
    {
        AIData contestantData = inRange[0].GetComponent<AIData>();
        Teams_EventManager.current.StatueStatus(inRange[0].GetComponent<AIData>().TeamName);
        destination = contestantData.teamBase;
        movement.Walk(agent, destination);
    }
    //-------------------------------------------------------Check if destination still valid--------------------------------------------
    private void CheckIfDestinationValid()
    {
        if (inRange.Count != 0)
        {
            AIData contestantData = inRange[0].GetComponent<AIData>();

            if (contestantData && destination != contestantData.teamBase)
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
            if (source != null)
            {
                source.Play();
                mPlaying = true;
            }

        }
    }

    public void DontMoveAnimate()
    {
        animator.SetBool("Move", false);
        if (mPlaying == true)
        {
            if (source != null)
            {
                source.Stop();
                mPlaying = false;
            }

        }
    }

    public void CheckAnim()
    {
        if (destination != null)
        {
            MoveAnimate();

        }

        if (destination == null)
        {
            DontMoveAnimate();

        }
    }
}
