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

    public bool hited = false;

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
        gameObject.GetComponent<Collider>().enabled = false;
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
        hited = false;
    }

    public void SpwanXValueChange(float xVlaue)
    {
        float yValue = transform.position.y;
        float zValue = transform.position.z;
        transform.position = new Vector3(xVlaue, yValue, zValue);
    }

    public void Hinted()
    {
        hited = true;
    }

    public bool HitedR()
    {
        return hited;
    }

}