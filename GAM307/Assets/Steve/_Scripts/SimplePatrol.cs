using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplePatrol : MonoBehaviour
{
    //if the enemy will wait at each point or not
    [SerializeField]
    bool patrolWaiting;

    //Wait time for each node
    [SerializeField]
    float totalwaitingtime = 3f;

    //Chance of Changing direction
    float chanceofswitching = 0.1f;

    //List of nodes to visit
    [SerializeField]
    List<Waypoint> patrolPoints = new List<Waypoint>();

    //Private variable for base behavoir
    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    public List<Waypoint> PatrolPoints
    {
        get
        {
            return patrolPoints;
        }

        set
        {
            patrolPoints = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.Log(" No Nav Mesh attached to " + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log(" Insufficient patrol points to be able to patrol ");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //is the destination close?
        if(travelling && navMeshAgent.remainingDistance <= 1.0f)
        {
            travelling = false;
            //are we going to wait in place?
            if(patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }

        }
        //If we are waiting already
        if(waiting)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer >= totalwaitingtime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    void SetDestination ()
    {
        if(patrolPoints !=null )
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }
    }

    void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= chanceofswitching)
        {
            patrolForward = !patrolForward;
        }

        if(patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.count;
        }
        else
        {
            if(-- currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.count - 1;
            }
        }
    }
}