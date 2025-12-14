using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public TextMeshProUGUI points;

    private void Update()
    {
        //points.text = ScoreSystem.Instance.TotalPoints.ToString();
    }

    public void UpdatePoints(int totalpoints)
    {
        points.text = totalpoints.ToString();
    }
}
