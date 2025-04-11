using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int finialScore;
    public TMP_Text scoreTxt;

    public int score;

    public void ScoreGiven(int colScore)
    {
        score = colScore;
        finialScore += score;
        scoreTxt.text = finialScore.ToString();
    }
}
