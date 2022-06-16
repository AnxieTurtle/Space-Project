using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    
    private PlayerController playerController;
    public GameObject player;
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnPoint;

    static public float speedGlobal = 1;
    static public int enemysInWave = 20;
    static public int waveNumber = 1;
    [SerializeField] private float spawnTime = 3f;

    void Start() {
        playerController = player.GetComponent<PlayerController>();

        StartCoroutine(StartLevel(100));
    }

    IEnumerator StartLevel(int enemysInWave) {
        //for(int i = 0; i < enemysInWave; i++) {
        //    yield return new WaitForSeconds(3f);
        //    int waveID = Random.Range(0, 2);
        //    SpawnWave(waveID);
        //}
        while(true) {
            yield return new WaitForSeconds(spawnTime);
            int waveID = Random.Range(0, 2);
            SpawnWave(waveID);
            //SpawnEnemy(0);
        }
    }

    void SpawnWave(int waveID) {
        //int rand = Random.Range(0, 2);
        int rand = 1;
        if(rand == 1) {
            rand = Random.Range(0, enemyPrefabs.Length);
            SpawnEnemy(rand);
        } else {
            switch(waveID) {
                case 0:
                    SpawnEnemy(0);
                    break;
                case 1:
                    SpawnEnemy(1);
                    break;
                case 2:
                    SpawnEnemy(2);
                    break;
                case 3:
                    SpawnEnemy(3);
                    break;
            }
        }
        
    }

    void SpawnEnemy(int enemyID) {
        int randSpawnPoint = Random.Range(0, spawnPoint.Length);
        Vector3 position = spawnPoint[randSpawnPoint].transform.position;
        Instantiate(enemyPrefabs[enemyID], position, enemyPrefabs[enemyID].transform.rotation);
        //Enemy enemy = Instantiate(enemyPrefabs[enemyID], position, enemyPrefabs[enemyID].transform.rotation).GetComponent<Enemy>();

        //int rand = Random.Range(1, 101);
        //if(rand <= 30)
        //    enemy.moveMode = 2;
    }
    void SpawnEnemy(int enemyID, int spawnPointPos) {
        Mathf.Clamp(spawnPointPos, 0, spawnPoint.Length-1);
        Vector3 position = spawnPoint[spawnPointPos].transform.position;
        Instantiate(enemyPrefabs[enemyID], position, enemyPrefabs[enemyID].transform.rotation);
    }
}
