using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer, obstacleLayer;
    
    //Patrolling 
    public Transform walkPointA;
    public Transform walkPointB;

    bool walkPointSet;
    public float walkPointRange;


    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttcked;

    //States
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;
    
    void Start()
    {
        player = GameObject.Find("PlayerObject").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        Vector3 directionToPlayer = player.position - transform.position;
        //float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        RaycastHit hit;

        if(!playerInSight && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerInSight && !playerInAttackRange)
        {
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, sightRange, obstacleLayer))
            {
                //Debug.Log("Player Blocked");
                Patroling();
            }
            else
            {
                //Debug.Log("Chase Started");
                ChasePlayer();
            }
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

            if (distanceWalkPoint.magnitude < 1f)
            {
                walkPointSet = true;
            }
        }

        else if (walkPointSet)
        {
            agent.SetDestination(walkPointA.position);

            Vector3 distanceWalkPoint = transform.position - walkPointA.position;

            if (distanceWalkPoint.magnitude < 1f)
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
