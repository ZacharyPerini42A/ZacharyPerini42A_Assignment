using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    //we always start  from Wave 0
    int startingWave = 0;

    //when calling this Corotuine, we need to specify which WaveConfig we want to spawn
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        //spawns an enemy until enemyCount == GetNumberOfEnemies()
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn the enemy from 
            //at the position specified by the waveConfig waypoints
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            //the wave will be selected from here and the enemy applied to it
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        //this will loop from startingWave until we reach the last within our List
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            //the coroutine will wait for all enemies in Wave to spawn
            //before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }



    // Start is called before the first frame update
    IEnumerator Start()
    {
        //loop the waves while true
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
