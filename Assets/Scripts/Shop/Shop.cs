using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject T_CompradoIt1;
    [SerializeField] GameObject B_Item1;
    [SerializeField] GameObject T_CompradoIt2;
    [SerializeField] GameObject B_Item2;
    int priceItem1 = 500;
    int priceItem2 = 1000;
    public static bool Item1Active = false;
    int avaliableScoreS = GameManager.instance.TotalPoints;


    // Boton de regresar
    public void Game()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("scene1");
    }

    public void Item1()
    {
        if ((avaliableScoreS >= priceItem1) && (Item1Active == false))
        {
            GameManager.instance.PointsMinus(priceItem1);
            Item1Active = true;
            T_CompradoIt1.SetActive(true);
            B_Item1.SetActive(false);
            PlayerShield.shield = true;
            avaliableScoreS = GameManager.instance.TotalPoints;
        }
        else
        {
            print("NO HAY SUFICIENTE");
        }
    }
    public void Item2()
    {
        if ((avaliableScoreS >= priceItem2) && (GameManager.instance.lifes <= 5))
        {
            GameManager.instance.PointsMinus(priceItem2);
            T_CompradoIt2.SetActive(true);
            B_Item2.SetActive(false);
            avaliableScoreS = GameManager.instance.TotalPoints;
            GameManager.instance.WinLife();
        }
        else
        {
            print("NO HAY SUFICIENTE DINERO O YA TIENE TODAS LAS VIDAS");
        }
    }
}
