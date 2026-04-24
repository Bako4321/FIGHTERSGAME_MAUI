using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject cloudPrefab;
    public GameObject CoinPrefab;
    public GameObject healthPowerUpPrefab;
    public GameObject gameOverMenu;
    public GameObject powerupPrefab;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public GameObject audioPlayer;
    public AudioClip powerUpSound;
    public AudioClip powerDownSound;
    public AudioClip coinSound;
    public AudioClip healthSound;
    public AudioClip explosionSound;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerupText;

    public int score;

    private bool gameOver;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0; 
        gameOver = false;

        CreateSky();

        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        InvokeRepeating("CreateEnemyThree", 3, 4);

        powerupText.text = "No Powerups Yet!";

        StartCoroutine(SpawnHealth());
        StartCoroutine(SpawnPowerup());

        StartCoroutine(SpawnCoinRoutine());
        IEnumerator SpawnCoinRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(10f, 18f)); // 4�5 per 2 minutes
                SpawnCoin();
            }
        }
    }

    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnPowerup()
    {
        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }

    void CreatePowerup()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.8f, 0f), 0), Quaternion.identity);
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
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.9f, horizontalScreenSize * 0.9f), verticalScreenSize, 0), Quaternion.identity);
    }
    
    void SpawnCoin()
    {
        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Screen.width / Screen.height;

        float x = Random.Range(-9f, 9f);
        float y = Random.Range(-4.5f, 0f);

        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(CoinPrefab, spawnPos, Quaternion.identity);
    }

    IEnumerator SpawnHealth()
    {
        float spawnTime = Random.Range(6, 8);
        yield return new WaitForSeconds(spawnTime);
        CreateHealth();
        StartCoroutine(SpawnHealth());
    }

    void CreateHealth()
    {
        Instantiate(healthPowerUpPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.8f, 0f), 0), Quaternion.identity);
    }

    public void ManagePowerupText(int powerupType)
    {
        switch (powerupType)
        {
            case 1: 
                powerupText.text = "Speed Boost!";
                break;
            case 2:
                powerupText.text = "Double Weapon!";
                break;
            case 3:
                powerupText.text = "Triple Weapon!";
                break;
            case 4:
                powerupText.text = "Shield!";
                break;
            default:
                powerupText.text = "No Powerups Yet!";
                break;
        }
    }

    public void PlaySound(int whichSound)
    {
        switch(whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerUpSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerDownSound);
                break;
            case 3:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(coinSound);
                break;
            case 4:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(healthSound);
                break;
            case 5:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(explosionSound);
                break;
        }
    }

    public void AddScore(int earnedScore)
    {
       
        score = score + earnedScore;
        scoreText.text = "Score:" + score;

    }

   public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameOver = true;
    }
 
}