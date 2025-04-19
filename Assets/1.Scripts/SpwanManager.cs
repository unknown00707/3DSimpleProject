using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class SpwanManager : MonoBehaviour
{
    public PoolManager poolManager;
    public string beatDataFile = "beat_data.json";
    public float gameStartTime = 1f;
    public float enemyLineOffset = 2f;
    public AudioSource audioSource;
    public Vector3[] pos;

    private List<BeatDataList.BeatInfo> beatTimes = new List<BeatDataList.BeatInfo>();
    private int beatIndex = 0;
    private bool gameStarted = false;

    void Start()
    {
        LoadBeatData();
        StartCoroutine(StartGameAfterDelay());
    }

    IEnumerator StartGameAfterDelay()
    {
        yield return new WaitForSeconds(gameStartTime);
        gameStarted = true;
        audioSource.Play();
        StartCoroutine(SpawnObjectsByBeat());
    }

    void LoadBeatData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, beatDataFile);

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            BeatDataList beatDataList = JsonUtility.FromJson<BeatDataList>("{\"beats\":" + jsonString + "}");

            if (beatDataList != null && beatDataList.beats != null)
            {
                beatTimes.AddRange(beatDataList.beats);
                beatTimes.Sort((a, b) => a.time.CompareTo(b.time));
            }
            else
            {
                Debug.LogError("JSON 데이터 파싱 오류: " + filePath);
            }
        }
        else
        {
            Debug.LogError("리듬 데이터 파일을 찾을 수 없습니다: " + filePath);
        }
    }

    IEnumerator SpawnObjectsByBeat()
    {
        while (gameStarted && beatIndex < beatTimes.Count)
        {
            float spawnTime = beatTimes[beatIndex].time;
            int line = beatTimes[beatIndex].line;
            string type = beatTimes[beatIndex].type;

            yield return new WaitUntil(() => audioSource.time >= spawnTime);

            SpawnObject(line, type);
            beatIndex++;
        }
    }

    void SpawnObject(int line, string type)
    {
        GameObject pooledObject = poolManager.GetPooledObject();
        if (pooledObject != null)
        {
            Vector3 spawnPosition = GetSpawnPosition(line);
            pooledObject.transform.position = spawnPosition;
            pooledObject.transform.GetChild(0).gameObject.SetActive(true);

            EnemyCommon common = pooledObject.GetComponent<EnemyCommon>();
            if (common != null)
            {
                common.collider.enabled = true;
            }

            if (type == "enemy")
            {
                EnemyControl enemyS = pooledObject.GetComponent<EnemyControl>();
                if (enemyS != null)
                {
                    enemyS.EnemySetBasic(false);
                }
            }
            else if (type == "bullet")
            {
                EnemyBullet enemyBulletS = pooledObject.GetComponent<EnemyBullet>();
                if (enemyBulletS != null)
                {
                    enemyBulletS.OnEnemeyBulletSet();
                }
            }
        }
    }

    Vector3 GetSpawnPosition(int line)
    {
        return new Vector3(line == 0 ? -enemyLineOffset : enemyLineOffset, StartPos().y, StartPos().z);
    }

    public Vector3 StartPos()
    {
        int ran = Random.Range(0, pos.Length);
        return pos[ran];
    }
}