using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 15;
    private float startDelay = 1;
    private float spawnInterval = 1.5f;
    private float spawnIntervalChangeRate = 0.1f; // spawnInterval'deki deðiþim miktarý
    private float maxSpawnInterval = 0.5f; // maksimum spawnInterval deðeri

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // spawnInterval deðerini her zaman deðiþtir
        spawnInterval = Mathf.Clamp(spawnInterval - spawnIntervalChangeRate * Time.deltaTime, maxSpawnInterval, spawnInterval);
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
