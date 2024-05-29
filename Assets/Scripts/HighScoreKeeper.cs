using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreKeeper : MonoBehaviour
{
    public Text highScoreText;
    public Text scoreText;

    private static int highScore;

    private void Start()
    {
        int score = Distance.distanceScoreStatic * PlayerController.coinScoreStatic;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = highScore.ToString();
    }
}
