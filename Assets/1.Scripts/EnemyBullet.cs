using UnityEngine;

public class EnemyBullet : EnemyCommon
{
    public bool isAttacked = false;
    
    // Update is called once per frame
    void Update()
    {
        if(isAttacked)
        {
            transform.position += RanVocter() * speed * Time.deltaTime;
            Invoke("Die", 3);
        }  
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(transform.GetChild(0).gameObject.activeInHierarchy && !isAttacked)
            transform.position += speed * Time.deltaTime * Vector3.back;
    }

    public void OnEnemeyBulletSet()
    {
        isAttacked = false;
        speed = 30f;
    }

    Vector3 RanVocter()
    {
        return new Vector3 (Random.Range(-360f, 360f), Random.Range(1f, 30f), Random.Range(1f, 360f));
    }
}
