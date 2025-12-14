using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TextMeshProUGUI T_points;
    public GameObject[] Lifes;
    public GameObject[] Shield;


    private void Start()
    {
        GameManager.instance.hud = this;

        // Sincroniza vidas
        for (int j = 0; j < Lifes.Length; j++)
        {
            Lifes[j].SetActive(j < GameManager.instance.lifes);
        }

        T_points.text = GameManager.instance.TotalPoints.ToString();
    }
    public void UpdatePoints(int Totalpoints)
    {
        T_points.text = Totalpoints.ToString();
    }
    public void LoseShield(int i)
    {
        Shield[i].SetActive(false);
    }
    public void LoseLife(int i)
    {
        if (i >= 0 && i < Lifes.Length)
            Lifes[i].SetActive(false);
    }
    public void WinLife(int i)
    {
        if (i >= 0 && i < Lifes.Length)
            Lifes[i].SetActive(true);
    }
    public void WinShield(int i)
    {
        if (i >= 0 && i < Shield.Length)
            Shield[i].SetActive(true);
    }
}
