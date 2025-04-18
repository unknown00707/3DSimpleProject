using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int conditionNum;
    public PlayerControl player;
    public ScoreManager scoreManager;

    int hitedCode = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && player.isAttack)
        {
            EnemyControl enemy = other.GetComponent<EnemyControl>();
            enemy.collider.enabled = false;

            hitedCode = enemy.hitCode;
            scoreManager.ScoreGiven(hitedCode * conditionNum );
            print("HitPoint");
            
            enemy.EnemySetBasic(true);
        }

        if (other.CompareTag("EnemyBullet") && player.isAttack)
        {
            EnemyBullet enemyBullet = other.GetComponent<EnemyBullet>();
            enemyBullet.collider.enabled = false;

            hitedCode = enemyBullet.hitCode;
            scoreManager.ScoreGiven(hitedCode * conditionNum );
            print("HitPoint");


            if(enemyBullet.isAttacked != true)
            {
                enemyBullet.isAttacked = true;
                enemyBullet.speed *= Random.Range(1f, 1.5f);
            }
            
        }
    }

}
