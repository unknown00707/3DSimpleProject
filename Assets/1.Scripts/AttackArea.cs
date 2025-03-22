using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int conditionNum;
    public PlayerControl player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && player.isAttack)
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("EnemyBullet") && player.isAttack)
        {
            EnemyBullet enemyBullet = other.GetComponent<EnemyBullet>();
            
            if(enemyBullet.isAttacked != true)
            {
                enemyBullet.isAttacked = true;
                enemyBullet.rigid.linearVelocity = Vector3.zero;
                enemyBullet.speed *= Random.Range(1, 1.5f);
            }
            
        }
    }
}
