using System.Collections;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Shield shield = other.GetComponent<Shield>();

            if (shield != null)
            {
                shield.ActivateShield(5f); // shield lasts 5 seconds
            }

            Destroy(gameObject);
        }
    }
}