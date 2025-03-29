using UnityEngine;

public class EnemyBullet : EnemyCommon
{
    public bool isAttacked = false;

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
    }

    Vector3 RandomVec()
    {
        float limtiRan = 320f;
        float ranX = Random.Range(-limtiRan, limtiRan);
        float ranY = Random.Range(0, limtiRan);
        float ranZ = Random.Range(0, limtiRan);
        return new Vector3(ranX, ranY, ranZ);
    }




    void OnEnable()
    {
        isAttacked = false;
        speed = 30f;
    }

}
