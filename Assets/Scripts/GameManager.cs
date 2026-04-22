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
    public GameObject CoinPrefab;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    void Start()
    {
        horizontalScreenSize = 15f;
        verticalScreenSize = 14.5f;

        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        InvokeRepeating("CreateEnemyThree", 3, 4);

        StartCoroutine(SpawnShieldRoutine());
        IEnumerator SpawnShieldRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(24f, 30f)); // 4–5 per 2 minutes
                SpawnShield();
            }
        }

        StartCoroutine(SpawnCoinRoutine());
        IEnumerator SpawnCoinRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(10f, 18f)); // 4–5 per 2 minutes
                SpawnCoin();
            }
        }
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
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * .9f, verticalScreenSize, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 7f, verticalScreenSize, 0), Quaternion.identity);
    }
    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-7f, 7f) * 6.5f, verticalScreenSize, 0), Quaternion.identity);
    }
    void SpawnShield()
    {
        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Screen.width / Screen.height;

        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-8f, -1f);

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(ShieldPrefab, spawnPos, Quaternion.identity);
    }
    void SpawnCoin()
    {
        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Screen.width / Screen.height;

        float x = Random.Range(-9f, 9f);
        float y = Random.Range(-8f, -2f);

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(CoinPrefab, spawnPos, Quaternion.identity);
    }
}