using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    void Awake()
    {
        pooledObjects = new List<GameObject>();
        BasicSet();
    }

    void BasicSet()
    {
        SpwanManager spwanManager = FindAnyObjectByType<SpwanManager>(); // SpwanManager 찾기

        foreach (GameObject prefab in objectToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(prefab);

                EnemyCommon common = obj.GetComponent<EnemyCommon>();
                if (common != null)
                {
                    common.spwanManager = spwanManager; // EnemyCommon에 SpwanManager 할당
                }

                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.SetParent(spwanManager.transform);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].transform.GetChild(0).gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null; // 모든 오브젝트가 활성화되어 있을 경우
    }
}