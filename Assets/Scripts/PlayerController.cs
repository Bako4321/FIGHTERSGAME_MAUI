using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    public int lives; 
    public GameManager gameManager; 
    public GameObject explosionPrefab; 
    private float playerSpeed;

    private float horizontalInput;
    private float verticalInput;


    private float horizontalScreenSize;
    private float verticalScreenSize;

    public GameObject bulletPrefab;
    public bool shieldActive;
    public GameObject thruster;
    public GameObject shield;

    public int weaponType;


    void Start()
    {
        playerSpeed = 6f;
        lives = 3; 
        shieldActive = false;
        weaponType = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ChangeLivesText(lives); 

        //This function is called at the start of the game
        
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }
    public void LoseALife()
    {
        if (!shieldActive)
        {
            lives--;
        }
        if (shieldActive)
        {
            StopCoroutine("ShieldPowerDown");
            shield.SetActive(false);
            shieldActive = false;
            gameManager.PlaySound(2);
            gameManager.ManagePowerupText(5);
        }
        gameManager.ChangeLivesText(lives); 
        if(lives ==0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            gameManager.GameOver();

            Destroy(this.gameObject);
        }
    }

    IEnumerator ShieldPowerDown()
    {
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
        shieldActive = false;
        gameManager.PlaySound(2);
        gameManager.ManagePowerupText(5);
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5);
        playerSpeed = 5f;
        thruster.SetActive(false);
        gameManager.PlaySound(2);
        gameManager.ManagePowerupText(5);
    }

    IEnumerator WeaponPowerDown()
    {
        yield return new WaitForSeconds(5);
        weaponType = 1;
        gameManager.PlaySound(2);
        gameManager.ManagePowerupText(5);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            int whichPowerup = Random.Range(1,5);
            gameManager.PlaySound(1);
            switch (whichPowerup)
            {
                case 1:
                    // speed boost and thruster active
                    playerSpeed  = 10f;
                    thruster.SetActive(true);
                    gameManager.ManagePowerupText(1);
                    StartCoroutine(SpeedPowerDown());
                    break;
                case 2:
                    // weapon type 2
                    weaponType = 2;
                    gameManager.ManagePowerupText(2);
                    StartCoroutine(WeaponPowerDown());
                    break;
                case 3:
                    // weapon type 3
                    weaponType = 3;
                    gameManager.ManagePowerupText(3);
                    StartCoroutine(WeaponPowerDown());
                    break;
                case 4:
                    // Shield powerup
                    shield.SetActive(true);
                    shieldActive = true;
                    gameManager.ManagePowerupText(4);
                    StartCoroutine("ShieldPowerDown");
                    break;
            }
        }
    }
    


    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(weaponType)
            {
                case 1:
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 45));
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.Euler(0, 0, -45));
                    break;
            }
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        float horizontalScreenSize = gameManager.horizontalScreenSize; 
        float verticalScreenSize = gameManager.verticalScreenSize; 

        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenSize || transform.position.x <= -horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }


    
        // VERTICAL clamp (bottom half only)
        float clampedY = Mathf.Clamp(
        transform.position.y,

        -4.5f, 0f);

        transform.position = new Vector3(transform.position.x, clampedY, 0);

    }

}
