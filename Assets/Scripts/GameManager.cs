// refresh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject ShieldPrefab;
    public GameObject cloudPrefab;
    
    public float horizontalScreenSize;
    public float verticalScreenSize;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;

        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        InvokeRepeating("CreateEnemyThree", 3, 4);
        InvokeRepeating("SpawnShield", 2f, 4f);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }


    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0), Quaternion.identity);
    }
    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-6f, 9f), 6.5f, 0f), Quaternion.identity);
    }
    void SpawnShield()
    {
        float x = Random.Range(-4f, 4f);
        float y = 5f; 

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(ShieldPrefab, spawnPos, Quaternion.identity);
    }
}