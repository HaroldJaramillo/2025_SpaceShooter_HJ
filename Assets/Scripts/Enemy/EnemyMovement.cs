using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 linearVelocity = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * Time.deltaTime);

        if (transform.position.x < -2.5)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("PlayerShoot")) || (collision.CompareTag("Player")))
        {
            Destroy(gameObject);
        }
    }
}
