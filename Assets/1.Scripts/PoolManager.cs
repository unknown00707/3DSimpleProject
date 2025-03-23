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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void BasicSet()
    {
        foreach (GameObject prefab in objectToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(prefab);
                obj.SetActive(false);

                if(obj.CompareTag("Enemy"))
                    pooledEnemy.Add(obj);
                if(obj.CompareTag("EnemyBullet"))
                    pooledEnemyBullet.Add(obj);

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
                if (!pooledEnemy[i].activeInHierarchy)
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
                if (!pooledEnemyBullet[i].activeInHierarchy)
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
