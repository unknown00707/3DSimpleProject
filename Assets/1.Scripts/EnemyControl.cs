using UnityEngine;


public class EnemyControl : EnemyCommon
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if(transform.GetChild(0).gameObject.activeInHierarchy)
            transform.position += speed * Time.deltaTime * Vector3.back;
    }
    
    public void EnemySetBasic(bool isAttacked)
    {
        transform.GetChild(0).gameObject.SetActive(!isAttacked); // body 
        transform.GetChild(1).gameObject.SetActive(isAttacked); // particle
    }
}
