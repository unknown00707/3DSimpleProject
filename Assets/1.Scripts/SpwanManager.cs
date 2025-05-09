using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    
    public PoolManager poolManager;
    public MusicManager musicManager;
    public Vector3[] pos;

    public Vector3 StartPos()
    {
        //초기 위치 설정
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
            // 반복 실행

            // yield return new WaitForSeconds(0.5f);

            
            //     GameObject enemyBullet = poolManager.GetPooledObject(false);
            //     EnemyBullet enemyBulletS = enemyBullet.GetComponent<EnemyBullet>();

            //     //enemyBulletS.OnSetBasicEnemey();
            //     enemyBulletS.OnSetBasicEnemey();
            //     enemyBulletS.OnEnemeyBulletSet();

            //     enemyBullet.transform.GetChild(0).gameObject.SetActive(true);
            
            
            GameObject enemy = poolManager.GetPooledObject(true);
            EnemyControl enemyS = enemy.GetComponent<EnemyControl>();

            
            enemyS.OnSetBasicEnemey();
            enemyS.EnemySetBasic(false);
            
            yield return new WaitForSeconds(musicManager.bpm);
        
        
        }
    }
}