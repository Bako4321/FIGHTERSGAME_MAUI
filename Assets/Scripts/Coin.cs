using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)
            {
                gm.AddScore(1); // Add however many points you want
            }

            Destroy(gameObject);
        }
    }
}