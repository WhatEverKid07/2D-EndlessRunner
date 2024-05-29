using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;
    public Text distanceScore;

    public static int distanceScoreStatic;

    void Update()
    {
        int tensDigit = Mathf.RoundToInt(player.position.x / 10f);

        distanceScore.text = tensDigit.ToString();

        distanceScoreStatic = tensDigit;
    }
}
