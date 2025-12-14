using UnityEngine;

public class EnemyShootM : MonoBehaviour
{
    Vector3 linearVelocity = Vector3.left;

    void Start()
    {
    }

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
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
