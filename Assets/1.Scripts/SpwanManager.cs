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
        int ran = Random.Range(0, 3);
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

            if(poolManager.GetPooledObject(false) != null)
            {
                GameObject enemyBullet = poolManager.GetPooledObject(false);
                enemyBullet.SetActive(true);
            }

            yield return new WaitForSeconds(5f);

            if(poolManager.GetPooledObject(true) != null)
            {
                GameObject enemy = poolManager.GetPooledObject(true);
                enemy.SetActive(true);
            }

            }
        
    }
}
