using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class KinematicStart : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public static bool Kinematic;


    void Update()
    {

        if (Kinematic == true)
        {
            playableDirector.Play();
        }
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("Scene1");
    }

}
