using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_spawner : MonoBehaviour {

    [SerializeField] List<GameObject> UFO_list;
    [SerializeField] int timeTrySpawn;
    [SerializeField] int RandomToSpawn;
    EnemySpawner Spawner;



	// Use this for initialization
	void Start () {
        Spawner = gameObject.GetComponent<EnemySpawner>();
            StartCoroutine(TrySpawnUFO());
	}



    IEnumerator TrySpawnUFO()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeTrySpawn);
            if (UnityEngine.Random.Range(1, RandomToSpawn+1) == 1)
            {
                Spawner.setStartingWave(UnityEngine.Random.Range(0, Spawner.getLenghtOfListWave()));
                Spawner.getActualWave().SetEnemyPrefab(UFO_list[UnityEngine.Random.Range(0, UFO_list.Count)]);
                Spawner.SpawnOneWave(Spawner.getActualWave());
            }
          
        }
    }
}
