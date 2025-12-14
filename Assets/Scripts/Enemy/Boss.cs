using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    SpriteRenderer spr;
    public int BossLifes = 3;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void BossloseLife()
    {
        BossLifes--;
        if (BossLifes == 2){
            spr.color = Color.yellow;
        }
        else if (BossLifes == 1)
        {
            spr.color = Color.red;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
