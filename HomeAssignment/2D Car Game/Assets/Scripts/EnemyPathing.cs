using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfig waveConfig;

    [SerializeField] int scoreValue = 5;

    //sound for point gained
    [SerializeField] AudioClip pointGained;
    [SerializeField] [Range(0, 1)] float pointGainedVolume = 0.75f;

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
            var enemyMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
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
            //obstacle destroyed by last waypoint will mean that player avoided it
            //hence adding score to scoreValue

            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            AudioSource.PlayClipAtPoint(pointGained, Camera.main.transform.position, pointGainedVolume);
            Destroy(gameObject);
          
        }
    }

    //set a waveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }

}
