using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                if (player.lives < 3)
                {
                    player.lives++;
                    FindFirstObjectByType<GameManager>().ChangeLivesText(player.lives);
                }
                else
                {
                    Object.FindFirstObjectByType<GameManager>().AddScore(1);
                }
            }

            Destroy(gameObject);
        }
    }
}
