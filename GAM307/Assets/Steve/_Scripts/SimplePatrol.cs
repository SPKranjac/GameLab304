using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplePatrol : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform player;
    public Transform startArea;


    private NavMeshAgent enemy;

    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();

        

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Point 1")
        {
            enemy.SetDestination(pos2.position);
        }

        if (other.tag == "Point 2")
        {
            enemy.SetDestination(pos3.position);
        }

        if (other.tag == "Point 3")
        {
            enemy.SetDestination(pos4.position);
        }

        if (other.tag == "Point 4")
        {
            enemy.SetDestination(pos1.position);
        }

        if (other.tag == "Player")
        {
            Debug.Log(" Player Detected");
            enemy.SetDestination(player.position);
            Debug.Log(" Following player for 3 seconds");
            PlayerFollow();
        }
    }

    IEnumerator PlayerFollow()
    {
        yield return new WaitForSeconds(3);
        Debug.Log(" Following player for 3 seconds");
        enemy.SetDestination(pos1.position);
        
    }
}