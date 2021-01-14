using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{

    //the selected enemy
    [SerializeField] GameObject enemyPrefab;

    //path that wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between spawns
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //number of enemies in the wave
    [SerializeField] int numberOfEnemies = 5;

    //speed of enemy
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GeteEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();
        
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

  

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }


    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

}
