using UnityEngine;

public class BossMove : MonoBehaviour
{
    Vector3 velocity;
    int step = 0;
    float speed = 1f;

    void Start()
    {
        transform.position = new Vector3(3f, 0f, transform.position.z);
        velocity = Vector3.left * speed; // adelante
    }

    void Update()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);

        switch (step)
        {
            case 0: // adelante
                if (transform.position.x <= 1f)
                {
                    transform.position = new Vector3(1f, transform.position.y, transform.position.z);
                    velocity = Vector3.up * speed;
                    step = 1;
                }
                break;

            case 1: // subir
                if (transform.position.y >= 0.598f)
                {
                    transform.position = new Vector3(transform.position.x, 0.265f, transform.position.z);
                    velocity = Vector3.down * speed; // BAJA ahora
                    step = 2;
                }
                break;

            case 2: // bajar
                if (transform.position.y <= -0.598f)
                {
                    transform.position = new Vector3(transform.position.x, -0.598f, transform.position.z);
                    velocity = Vector3.right * speed; // ahora va atrás
                    step = 3;
                }
                break;

            case 3: // atrás
                if (transform.position.x >= 3f)
                {
                    transform.position = new Vector3(3f, 0f, transform.position.z);
                    velocity = Vector3.left * speed;
                    step = 0;
                }
                break;
        }
    }
}
