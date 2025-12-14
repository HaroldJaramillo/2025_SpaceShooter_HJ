using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void BStart()
    {
        SceneManager.LoadScene("Kinematic1");
        KinematicStart.Kinematic = true;
    }

}
