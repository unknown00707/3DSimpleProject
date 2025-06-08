using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int finialScore;
    public TMP_Text scoreTxt;
    public TMP_Text recastingTxt;
    public PlayerControl player;

    int score;

    void LateUpdate()
    {
        if (finialScore <= 0) finialScore = 0;

        scoreTxt.text = "Score : " + finialScore.ToString();
        recastingTxt.text = "RecastingTime : " + player.reCastingTime.ToString("F1");
    }

    public void ScoreGiven(int colScore)
    {
        score = colScore;

        if ((finialScore <= 0) && (score < 0)) finialScore = 0; finialScore += score;
    }
}
