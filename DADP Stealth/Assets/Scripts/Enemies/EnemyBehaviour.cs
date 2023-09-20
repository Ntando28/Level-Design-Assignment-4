using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float visionAngle = 45f; // The angle of the vision cone.
    public float visionRange = 10f; // The range of the vision cone.
    public LayerMask obstacleLayer; // The layer(s) for obstacles.

    public Transform player; // The player's transform.

    private void Start()
    {
        // Find the player object (you can replace this with any method to locate the player).
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 dirToPl = player.position - transform.position;
        float angToPl = Vector3.Angle(transform.forward, dirToPl);
        
        Debug.DrawRay(transform.position,dirToPl,Color.red, 2f);
        
        if (CanSeePlayer())
        {
            // The enemy can see the player.
            Debug.Log("Player detected!");
        }
    }

    private bool CanSeePlayer()
    {
        if (player == null)
            return false;

        // Calculate the direction from the enemy to the player.
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the angle between the enemy's forward vector and the direction to the player.
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Check if the player is within the vision angle and range.
        if (angleToPlayer < visionAngle * 0.5f)
        {
            // Check if there are obstacles between the enemy and the player.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, visionRange, obstacleLayer))
            {
                // An obstacle is blocking the view.
                return false;
            }

            // No obstacles, and the player is within the vision cone.
            return true;
        }

        // Player is outside the vision angle or range.
        return false;
    }
}
