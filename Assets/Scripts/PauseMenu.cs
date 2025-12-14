using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool GamePaused = false;

    [SerializeField] InputActionReference pause;

    private void OnEnable()
    {
        pause.action.Enable();
        pause.action.started += OnPause;
    }
    private void OnPause(InputAction.CallbackContext obj)
    {
        if (PauseMenu == null)
            return;

        if (GamePaused == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            GamePaused = true;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            GamePaused = false;
        }
    }
    public void inGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GamePaused = true;
    }

    public void Shop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDisable()
    {
        pause.action.started -= OnPause;
        pause.action.Disable();
    }


}
