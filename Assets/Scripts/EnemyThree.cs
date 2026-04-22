using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private int switchDirection = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchDirection = (Random.value < 0.5f) ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(switchDirection, -0.5f, 0) * Time.deltaTime * 9f);

        if (transform.position.x <= -14f)
        {
            switchDirection = 1;
        }

        if (transform.position.x >= 14f)
        {
            switchDirection = -1;
        }

        if (transform.position.y < -8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}