using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    
    public PoolManager poolManager;

    public Vector3[] pos;

    public Vector3 StartPos()
    {
        int ran = Random.Range(0, pos.Length);
        return pos[ran];
    }

    void Start()
    {
        StartCoroutine(Spwan());
    }

    IEnumerator Spwan()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            
                GameObject enemyBullet = poolManager.GetPooledObject(false);
                EnemyBullet enemyBulletS = enemyBullet.GetComponent<EnemyBullet>();

                //enemyBulletS.OnSetBasicEnemey();
                enemyBulletS.OnSetBasicEnemey();
                enemyBulletS.OnEnemeyBulletSet();

                enemyBullet.transform.GetChild(0).gameObject.SetActive(true);
            

            yield return new WaitForSeconds(5f);

            
                GameObject enemy = poolManager.GetPooledObject(true);
                EnemyControl enemyS = enemy.GetComponent<EnemyControl>();

                enemyS.OnSetBasicEnemey();
                enemyS.EnemySetBasic(false);
        }

            
        
    }
}
