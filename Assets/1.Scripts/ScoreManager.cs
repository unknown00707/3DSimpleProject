using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int finialScore;
    public TMP_Text scoreTxt;

    public int score;

    void LateUpdate()
    {
        if (finialScore <= 0) finialScore = 0;
    }

    public void ScoreGiven(int colScore)
    {
        score = colScore;

        if ((finialScore <= 0) && (score < 0)) finialScore = 0; finialScore += score;

        scoreTxt.text = finialScore.ToString();
    }
}
