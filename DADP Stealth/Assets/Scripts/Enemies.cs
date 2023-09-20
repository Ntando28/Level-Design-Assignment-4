using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patrolling 
    public Transform walkPointA;
    public Transform walkPointB;

    bool walkPointSet;
    public float walkPointRange;


    //Attacking 
    public float timeBetweenAttcaks;
    bool alreadyAttcked;

    //States
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSight && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerInSight && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInSight && playerInAttackRange)
        {
            Attacking();
        }


    }



    private void Patroling()
    {
       

        if (!walkPointSet)
        {
            agent.SetDestination(walkPointB.position);

            Vector3 distanceWalkPoint = transform.position - walkPointB.position;

            if (distanceWalkPoint.magnitude < 5f)
            {
                walkPointSet = true;
            }
        }

        else if (walkPointSet)
        {
            agent.SetDestination(walkPointA.position);

            Vector3 distanceWalkPoint = transform.position - walkPointA.position;

            if (distanceWalkPoint.magnitude < 5f)
            {
                walkPointSet = false;
            }

        }



    }

    

    private void  Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
    }




  
}
