using UnityEngine;


public class EnemyControl : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rigid;
    public SpwanManager spwanManager;

    Vector3 startPos = new Vector3(0,1.77f,200);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);

        if(transform.position.z < -150)
        {
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

    void Die()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        transform.position = Vector3.zero;
        rigid.linearVelocity = Vector3.zero;
        startPos = spwanManager.StartPos();
        gameObject.transform.position = startPos;
    }

}
