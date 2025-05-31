using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    
    public PoolManager poolManager;
    public MusicManager musicManager;
    public float[] pos;

    void Start()
    {
        StartCoroutine(Spwan());
    }

    IEnumerator Spwan()
    {
        while (true)
        {
            // 반복 실행

            // yield return new WaitForSeconds(0.5f);


            //     GameObject enemyBullet = poolManager.GetPooledObject(false);
            //     EnemyBullet enemyBulletS = enemyBullet.GetComponent<EnemyBullet>();

            //     //enemyBulletS.OnSetBasicEnemey();
            //     enemyBulletS.OnSetBasicEnemey();
            //     enemyBulletS.OnEnemeyBulletSet();

            //     enemyBullet.transform.GetChild(0).gameObject.SetActive(true);
            BeatmapData loadedBeatmap = musicManager.GetLoadedBeatmapData();
            float waitTimeCul;

            foreach (var note in loadedBeatmap.tracks[0].notes)
            {
                GameObject enemy = poolManager.GetPooledObject(true);
                EnemyControl enemyS = enemy.GetComponent<EnemyControl>();

                if (note.type == "first")
                {
                    enemyS.SpwanXValueChange(pos[note.lane - 1]);
                    enemyS.EnemySetBasic(false);
                    //print("첫 소환");
                    continue;
                }

                int subdivision = (note.subdivision != 0) ? note.subdivision : 1;
                waitTimeCul =  60f / loadedBeatmap.meta.bpm * note.beat  / subdivision;
                //print($"분박 : {subdivision}, 비트 : {note.beat}, BPM : {loadedBeatmap.meta.bpm}");
                //print(waitTimeCul);

                yield return new WaitForSeconds(waitTimeCul);

                //print("넘어왔당");

                enemyS.SpwanXValueChange(pos[note.lane - 1]);
                enemyS.EnemySetBasic(false);

                //print("소환!");
            }
            break;       
        }
    }
}