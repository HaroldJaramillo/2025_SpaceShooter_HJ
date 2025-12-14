using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public HUD hud;
    public int TotalPoints { get { return Totalpoints; } }
    public int Totalpoints;
    public int ScorePoints;
    public int lifes = 4;
    public int shield = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    public void PointsPlus(int pointsToPlus)
    {
        Totalpoints += pointsToPlus;

        if (hud != null)
            hud.UpdatePoints(Totalpoints);
    }
    public void PointsMinus(int pointsToMinus)
    {
        Totalpoints -= pointsToMinus;

        if (hud != null)
            hud.UpdatePoints(Totalpoints);
    }

    public void LoseLife()
    {
        if (shield <= 0)
        {
            lifes--;

            if (hud != null)
                hud.LoseLife(lifes);
        }
        else
        {
            shield--;

            if (hud != null && shield >= 0)
                hud.LoseShield(shield);
        }
        if ((lifes <= 0) && (shield <= 0))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void WinLife()
    {
        lifes++;

        if (hud != null)
            hud.WinLife(lifes - 1);
    }
    public void WinShield()
    {
        shield++;

        if (hud != null)
            hud.WinShield(shield - 1);
    }

    public void PointsSpawnE(int i)
    {
        ScorePoints = ScorePoints+i;
    }
}
