using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 5f;

    private float direction;

    void Start()
    {
        // Randomly decide: spawn from left (-8) or right (+8)
        if (Random.value < 0.5f)
        {
            // Spawn on left side
            transform.position = new Vector3(-15f, Random.Range(-5f, 5f), 0f);
            direction = 1f; // move right
        }
        else
        {
            // Spawn on right side
            transform.position = new Vector3(15f, Random.Range(-7f, 7f), 0f);
            direction = -1f; // move left
        }
    }

    void Update()
    {
        // Move horizontally
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Destroy when off screen
        if (transform.position.x > 15f || transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}