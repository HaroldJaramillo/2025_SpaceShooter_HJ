using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void GORestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        GameManager.instance.lifes = 4;
        GameManager.instance.shield = 0;
    }

    public void InitalMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

