using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rigid;
    public bool isAttacked = false;

    Vector3 startPos;

    public SpwanManager spwanManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isAttacked)
            rigid.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
        else
        {
            rigid.AddForce(RandomVec() * speed * Time.deltaTime, ForceMode.Impulse);
            Invoke("Die", 3);
        }
        
        if(transform.position.z < -150)
        {
            Die();
        }
    }

    Vector3 RandomVec()
    {
        float limtiRan = 320f;
        float ranX = Random.Range(-limtiRan, limtiRan);
        float ranY = Random.Range(0, limtiRan);
        float ranZ = Random.Range(0, limtiRan);
        return new Vector3(ranX, ranY, ranZ);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        isAttacked = false;
        speed = 30f;
        transform.position = Vector3.zero;
        rigid.linearVelocity = Vector3.zero;
        startPos = spwanManager.StartPos();
        gameObject.transform.position = startPos;
    }

}
