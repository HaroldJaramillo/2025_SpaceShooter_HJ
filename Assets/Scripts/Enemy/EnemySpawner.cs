using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] GameObject Boss1;

    [SerializeField] Transform spawnLineTop;
    [SerializeField] Transform spawnLineBottom;


    private GameObject SpawnEnemy(GameObject prefab, Vector3 top, Vector3 bottom)
    {
        float t = Random.Range(0f, 1f);
        Vector3 startPosition = Vector3.Lerp(top, bottom, t);
        return Instantiate(prefab, startPosition, prefab.transform.rotation);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LineSpawning());

    }

    IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;
        bool boss = false;

        for (int h = 0; GameManager.instance.Totalpoints < 20000; h++)
        {

            if (GameManager.instance.ScorePoints >= 6000)
            {
                GameManager.instance.ScorePoints = 0;
                boss = false;
            }

            while (GameManager.instance.ScorePoints < 150)
            {
                SpawnEnemy(enemyPrefab1, lineTop, lineBottom);
                yield return new WaitForSeconds(1f);
            }
            while (GameManager.instance.ScorePoints < 1000)
            {
                SpawnEnemy(enemyPrefab2, lineTop, lineBottom);
                yield return new WaitForSeconds(1f);
            }
            if (GameManager.instance.ScorePoints >= 1000 && boss == false)
            {
                GameObject bossObj = SpawnEnemy(Boss1, lineTop, lineBottom);
                yield return new WaitForSeconds(1f);

                while (bossObj != null)
                {
                    yield return null;
                }
            }
        }
        if (GameManager.instance.Totalpoints >= 20000)
        {
            SceneManager.LoadScene("END");
        }
    }
}
