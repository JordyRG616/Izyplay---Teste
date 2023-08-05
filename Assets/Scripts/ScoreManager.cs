using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreDisplay;
    private int score;


    public void RaiseScore(int value)
    {
        score += value;
        scoreDisplay.text = "Score: " + score.ToString("000");
    }

    public void MultiplyScore(int multiplier)
    {
        score *= multiplier;
        scoreDisplay.text = "Score" + score.ToString("000");
    }
}
