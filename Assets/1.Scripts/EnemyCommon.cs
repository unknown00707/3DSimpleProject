using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public float speed;
    public SpwanManager spwanManager;
    public new Collider collider;

    public int hitCode;

    public int damage;

    bool hited = false;
    bool playerHiting;

    Vector3 startPos = new Vector3(0, 0, 100);

    void Start()
    {
        OnSetBasicEnemey();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected virtual void FixedUpdate()
    {
        if (transform.position.z < -7)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.GetComponent<ScoreManager>().ScoreGiven(-hitCode);
            print("DiePoint");
            Die();
            OnSetBasicEnemey();
        }
    }

    public void Die()
    {
        switch (gameObject.tag)
        {
            case "Enemy":
                gameObject.GetComponent<EnemyControl>().EnemySetBasic(true);
                break;
            case "EnemyBullet":
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
 

    }

    public void OnSetBasicEnemey()
    {
        transform.position = Vector3.zero;
        gameObject.transform.position = startPos;
        collider.enabled = true;
    }

    public void SpwanXValueChange(float xVlaue)
    {
        float yValue = transform.position.y;
        float zValue = transform.position.z;
        transform.position = new Vector3(xVlaue, yValue, zValue);
    }

    public void Hinted(bool playerhit)
    {
        hited = true;
        playerHiting = playerhit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hited && playerHiting)
        {
            collider.enabled = false;
            Die();
            AttackArea attackArea = other.GetComponent<AttackArea>();
            switch (other.gameObject.name)
            {
                case "Perfect Attack Area ":
                    attackArea.ScoreCulFEnemy(hitCode, 3);
                    break;
                case "Good Attack Area ":
                    attackArea.ScoreCulFEnemy(hitCode, 2);
                    break;
                case "Bad Attack Area ":
                    attackArea.ScoreCulFEnemy(hitCode, 1);
                    break;
            }
        }
    }
}