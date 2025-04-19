using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    public float speed;
    public SpwanManager spwanManager;
    public new Collider collider;

    public int hitCode;

    public int damage;

    Vector3 startPos;

    // Start 함수에서 OnSetBasicEnemey 호출 제거
    // void Start()
    // {
    //     OnSetBasicEnemey();
    // }

    void FixedUpdate()
    {
        if(transform.position.z < -7 && collider.enabled == true)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            scoreManager.GetComponent<ScoreManager>().ScoreGiven(-hitCode);
            print("DiePoint");
            Die();
            OnSetBasicEnemey(); // Die 후 재활용 시 초기화
        }
        else if (transform.position.z < -7 && collider.enabled == false)
        {
            Die();
            OnSetBasicEnemey(); // Die 후 재활용 시 초기화
        }
    }

    public void Die()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnSetBasicEnemey()
    {
        transform.position = Vector3.zero; // 기본 위치 초기화 (재활용 시)
        if (spwanManager != null)
        {
            startPos = spwanManager.StartPos();
            // gameObject.transform.position = startPos; // SpwanManager에서 위치 설정하므로 제거
        }

        // collider.enabled = true; // SpwanManager에서 활성화
    }
}