using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float enemyMoveSpeed = 2f;

    [SerializeField] WaveConfig waveConfig;

    //saves the desired waypoint destination
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //get the list waypoints from waveConfig
        waypoints = waveConfig.GetWaypoints();
        //set the start position of enemy to waypoint 0
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //sets a target position to the desired waypoint
            var targetPosition = waypoints[waypointIndex].transform.position;

            //sets z axis to always 0
            targetPosition.z = 0f;
            var enemyMovement = enemyMoveSpeed * Time.deltaTime;
            //the Enemy is moving towards targetPosition at the give enemyMovespeed, from the current location
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            //if reached target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        //if reached last waypoint
        else
        {
            Destroy(gameObject);
        }

    }
}
