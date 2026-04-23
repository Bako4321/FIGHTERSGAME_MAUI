using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.ActivateShield(shieldDuration);
            }

            Destroy(gameObject);
        }
    }
}