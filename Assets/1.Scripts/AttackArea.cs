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
            hitedCode = other.GetComponent<EnemyControl>().hitCode;
            scoreManager.ScoreGiven(hitedCode * conditionNum );
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("EnemyBullet") && player.isAttack)
        {
            EnemyBullet enemyBullet = other.GetComponent<EnemyBullet>();
            hitedCode = enemyBullet.hitCode;
            scoreManager.ScoreGiven(hitedCode * conditionNum );

            if(enemyBullet.isAttacked != true)
            {
                enemyBullet.isAttacked = true;
                enemyBullet.rigid.linearVelocity = Vector3.zero;
                enemyBullet.speed *= Random.Range(0.1f, 0.5f);
            }
            
        }
    }

}
