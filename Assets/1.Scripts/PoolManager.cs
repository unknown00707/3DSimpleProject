using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> pooledEnemy;
    public List<GameObject> pooledEnemyBullet;
    public GameObject[] objectToPool;
    public int amountToPool;

    public SpwanManager spwanManager;

    void Awake()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledEnemy = new List<GameObject>();
        pooledEnemyBullet = new List<GameObject>();

        BasicSet();
    }

    void BasicSet()
    {
        foreach (GameObject prefab in objectToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(prefab);
                SpwanManager spwanManager = FindAnyObjectByType<SpwanManager>();
                if(obj.CompareTag("Enemy"))
                {
                    obj.GetComponent<EnemyControl>().spwanManager = spwanManager;
                    pooledEnemy.Add(obj);
                }
                if(obj.CompareTag("EnemyBullet"))
                {
                    obj.GetComponent<EnemyBullet>().spwanManager = spwanManager;
                    pooledEnemyBullet.Add(obj);
                }
                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.SetParent(spwanManager.gameObject.transform); // set as children of Spawn Manager
            }
        }
    }

    public GameObject GetPooledObject(bool isEnemy)
    {
        GameObject gameObject;

        if(isEnemy)
        {
            // For as many objects as are in the pooledObjects list
            for (int i = 0; i < amountToPool; i++)
            {
                // if the pooled objects is NOT active, return that object 
                if (!pooledEnemy[i].transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    gameObject = pooledEnemy[i];
                    return gameObject;
                }
            }
        }
        else
        {
            // For as many objects as are in the pooledObjects list
            for (int i = 0; i < amountToPool; i++)
            {
                // if the pooled objects is NOT active, return that object 
                if (!pooledEnemyBullet[i].transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    gameObject = pooledEnemyBullet[i];
                    return gameObject;
                }
            }
        }
        
        
        // otherwise, return null   
        return null;
    }
}