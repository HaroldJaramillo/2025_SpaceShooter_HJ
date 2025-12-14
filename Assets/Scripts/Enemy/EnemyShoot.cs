using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectile;
    public float speed;
    public float shootInterval;
    public Vector3 direction = Vector3.down;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            transform.Translate(direction * speed * Time.deltaTime);
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
