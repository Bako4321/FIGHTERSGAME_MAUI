using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)
            {
                gm.AddScore(1); // Add 1 point (you can change this value)
            }

            Destroy(gameObject);
        }
    }
}