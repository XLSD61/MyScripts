using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class Spawner : MonoBehaviour
{
    [SerializeField] LevelReferenceHolder levelReferenceHolder;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject enemyHolder;
    [SerializeField] Transform spawnerPoz;
    [SerializeField] float invokeTime;
    [SerializeField] float repeatRate;
    [SerializeField] SplineComputer splineComputer;
    int spawnCount;
    [SerializeField] int bossRange;
    GameObject enemy;

    private void Start()
    {
        InvokeRepeating(nameof(EnemySpawn), invokeTime, repeatRate);
    }


    void EnemySpawn()
    {
        if (levelReferenceHolder.enemyCount >0)
        {
            SetEnemyCount();
            spawnCount++;
            if (spawnCount == bossRange)
            {
                enemy = Instantiate(bossPrefab, spawnerPoz.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().PathFollow(splineComputer);
                enemy.transform.SetParent(enemyHolder.transform);

                spawnCount = 0;
            }
            else
            {
                enemy = Instantiate(enemyPrefab, spawnerPoz.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().PathFollow(splineComputer);
                enemy.transform.SetParent(enemyHolder.transform);
            }
        }
       
       
    }


    void SetEnemyCount()
    {
        levelReferenceHolder.enemyCount--;
        EventManager.GamePlayEnemyCount(levelReferenceHolder.enemyCount);
    }
}
