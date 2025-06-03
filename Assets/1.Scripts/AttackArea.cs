using System.Collections;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public PlayerControl playerControl;
    public ScoreManager scoreManager;

    public void ScoreCulFEnemy(int hitCode, int conditionNum)
    {
        int hitedCode = hitCode;
        conditionNum = playerControl.isUltimate ? 3 : conditionNum;
        scoreManager.ScoreGiven(hitedCode * conditionNum);
        print("HitPoint" + conditionNum);
    }
}
