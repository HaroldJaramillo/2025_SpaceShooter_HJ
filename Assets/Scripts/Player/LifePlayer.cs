using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShoot") || (collision.CompareTag("Enemy1")) || (collision.CompareTag("Enemy2")) || (collision.CompareTag("Boss1")))
        {
            GameManager.instance.LoseLife();
        }
    }

}
