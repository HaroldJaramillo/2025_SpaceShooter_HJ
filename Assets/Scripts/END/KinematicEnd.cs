using UnityEngine;
using UnityEngine.Playables;

public class KinematicEnd : MonoBehaviour
{
    public PlayableDirector timeline;

    void Start()
    {
        timeline.stopped += OnCinematicFinished;
        timeline.Play();
    }

    void OnCinematicFinished(PlayableDirector director)
    {
        Application.Quit();
    }
}
