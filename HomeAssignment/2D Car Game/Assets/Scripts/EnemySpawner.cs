using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //a list of waveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //we start from wave 0


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start coroutine that spawns all enemies in current wave
            yield return StartCoroutine(spawnAllWaves());
        }
        while (looping); //(looping == true)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //specify which Wave to spawn enemies from
    private IEnumerator spawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            //loop to spawn all enemies in wave
            //spawn the enemy from waveConfig we need to spawn enemies from
            var newEnemy = Instantiate(
                            waveToSpawn.GeteEnemyPrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);
            //applying the enemy to this wave
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            //wait timeBetweenSpawns before spawning more enemies
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }

    }   

    private IEnumerator spawnAllWaves()
    {
        //loop
        foreach(WaveConfig currentWave in waveConfigList)
        {
            yield return StartCoroutine(spawnAllEnemiesInWave(currentWave));
        }
    }
 
}
