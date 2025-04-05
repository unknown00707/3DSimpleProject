using UnityEngine;


public class EnemyControl : EnemyCommon
{
    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
