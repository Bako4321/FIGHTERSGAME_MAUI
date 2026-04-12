using UnityEngine;

public class EnemyThree : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -8f) ;
        {
            Destroy(gameObject);
        }
    }
}