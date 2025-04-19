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
    
    Vector3 startPos;

    void Start()
    {
        OnSetBasicEnemey();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void FixedUpdate()
    {
        if(transform.position.z < -7 && collider.enabled == true)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.GetComponent<ScoreManager>().ScoreGiven(-hitCode);
            print("DiePoint");
            Die();
            OnSetBasicEnemey();
        }
        else if (transform.position.z < -7 && collider.enabled == false)
        {
            Die();
            OnSetBasicEnemey();
        }
    }

    public void Die()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnSetBasicEnemey()
    {
        transform.position = Vector3.zero;
        if (spwanManager != null)
        {
            startPos = spwanManager.StartPos();
            gameObject.transform.position = startPos;
        }

        collider.enabled = true;
    }
}