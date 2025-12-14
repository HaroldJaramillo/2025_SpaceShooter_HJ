using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance { get; private set; }
    public Boss boss;
    public AudioClip Shoot;
    public AudioClip Burst1;
    public AudioClip Burst2;
    [SerializeField] float speed = 1.5f;
    // Update is called once per frame

    public void Start()
    {
        AudioManager.Instance.SoundON(Shoot);
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        Destroy(gameObject, 5f);
    }
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1"))
        {
            AudioManager.Instance.SoundON(Burst1);
            Destroy(gameObject);
            GameManager.instance.PointsPlus(10);
            GameManager.instance.PointsSpawnE(10);
        }

        if (collision.CompareTag("Enemy2"))
        {
            AudioManager.Instance.SoundON(Burst1);
            Destroy(gameObject);
            GameManager.instance.PointsPlus(50);
            GameManager.instance.PointsSpawnE(50);
        }

        if (collision.CompareTag("Boss1"))
        {
            Destroy(gameObject);
            BossLife();
            if (Boss.instance.BossLifes == 0)
            {
                AudioManager.Instance.SoundON(Burst2);
                GameManager.instance.PointsPlus(5000);
                GameManager.instance.PointsSpawnE(5000);
            }
        } 
    }

    public void BossLife()
    {
        Boss.instance.BossloseLife();
    }
}
