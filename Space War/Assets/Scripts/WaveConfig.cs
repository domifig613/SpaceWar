﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float time_to_next_spawn_after_start = 3f;
    [SerializeField] int waveControl; //1=destroy if last wave point, 2 = stop in last wavePoint, 3 = loopingInSomePoint
    [SerializeField] int ReturnWaipoint;
    public void SetEnemyPrefab(GameObject enemy)
    {
        enemyPrefab = enemy;
    }
    public GameObject GetEnemyPrefab(){return enemyPrefab;}     //get 6 first serializefield
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetTimeToNextWave() { return time_to_next_spawn_after_start; }
    public int GetWaveControler() { return waveControl; }
    public int GetPointToLoopingMove() { return ReturnWaipoint; }




}
