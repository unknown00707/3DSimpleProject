using UnityEngine;

public class RayCastForAttackArea : MonoBehaviour
{
    public PlayerControl player;
    public LayerMask layerMask;
    RaycastHit hitInfo;
    Vector3 offset = new Vector3(0, 1.5f, 0);
    void Update()
    {
        Debug.DrawRay(transform.position + offset, transform.forward * 10f, Color.green);

        if (Physics.Raycast(transform.position + offset, transform.forward, out hitInfo, 10f, layerMask, QueryTriggerInteraction.Collide))
        {
            hitInfo.transform.gameObject.GetComponent<EnemyControl>().Hinted(player.isAttack);
        }
    }
}
