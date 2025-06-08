using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackArea : MonoBehaviour
{
    public PlayerControl player;
    public ScoreManager scoreManager;
    public List<Collider> objs;
    public Transform[] transforms;

    int comditonNum;
    public void ScoreCulFEnemy(int hitCode, int conditionNum)
    {
        int hitedCode = hitCode;
        conditionNum = player.isUltimate ? 3 : conditionNum;
        scoreManager.ScoreGiven(hitedCode * conditionNum);
        print("HitPoint" + conditionNum);
    }

    void Update()
    {
        if (player.isAttack && (objs.Count >= 1))
        {
            Attacking();
        }
    }
    public void Attacking()
    {
        print("S");
        Collider obj = objs[0];
        objs.RemoveAt(0);
        switch (obj.tag)
        {
            case "Enemy":
                EnemyControl enemyC = obj.GetComponent<EnemyControl>();
                enemyC.EnemySetBasic(true);
                enemyC.collider.enabled = false;
                break;
            case "EmeyBullet":
                EnemyBullet enemyB = obj.GetComponent<EnemyBullet>();
                enemyB.Die();
                enemyB.collider.enabled = false;
                break;
        }
        print("SA");
        CulTrans(obj.transform);
        print("SAAAAA");
    }

    void CulTrans(Transform enemyT)
    {
        if (enemyT.CompareTag("Enemy"))
        {
            comditonNum = enemyT.GetComponent<EnemyControl>().hitCode;
        }
        else if (enemyT.CompareTag("EmeyBullet"))
        {
            comditonNum = enemyT.GetComponent<EnemyBullet>().hitCode;
        }

        if (transforms[3].position.z < enemyT.position.z && (enemyT.position.z < transforms[2].position.z)) //  "Bad Attack Area"
        {
            ScoreCulFEnemy(comditonNum, 1);
        }
        else if (transforms[2].position.z < enemyT.position.z && (enemyT.position.z < transforms[1].position.z)) //  "Perfect Attack Area"
        {
            ScoreCulFEnemy(comditonNum, 3);
        }
        else if (transforms[1].position.z < enemyT.position.z && (enemyT.position.z < transforms[0].position.z)) //  "Good Attack Area"
        {
            ScoreCulFEnemy(comditonNum, 2);
        }
        else //  "Bad Attack Area"
        {
            ScoreCulFEnemy(comditonNum, 1);
        }
        print("SAA");
    }

    void OnTriggerEnter(Collider other)
    {
        objs.Add(other);
    }
}

