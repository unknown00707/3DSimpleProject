using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public float speed;
    public SpwanManager spwanManager;
    public Rigidbody rigid;

    public int hitCode;
    
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(transform.position.z < -7)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.GetComponent<ScoreManager>().ScoreGiven(-hitCode);
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        transform.position = Vector3.zero;
        rigid.linearVelocity = Vector3.zero;
        if (spwanManager != null)
        {
            startPos = spwanManager.StartPos();
            gameObject.transform.position = startPos;
        }
    }
}
