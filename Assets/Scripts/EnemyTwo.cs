using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }
    }
}