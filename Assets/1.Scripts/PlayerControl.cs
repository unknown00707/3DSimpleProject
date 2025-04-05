using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Vector3 plusVec = new Vector3 (2, 0, 0);

    protected int moveValue = 1;
    public float reCastingTime = 0f; // 궁극기 회전 시간
    protected float castingTime = 3f; // 궁극기 시전 시간

    bool isA;
    bool isD;
    bool isLeftArrow;
    bool isRightArrow;
    public bool isSpace;

    public bool isAttack;
    public bool isAttackHolding; // 궁극기 조건 
    public bool isUltimate; // 궁극기
    public bool isCharging;

    float arrow;

    void Update()
    {
        Move(arrow);
        Chliking();
        Ultimate();
    }

    void Move(float arrow)
    {
        if(arrow == -1 && !(transform.position.x <= -moveValue))
        {
            if(isA || isLeftArrow)
            {
                transform.position += -plusVec;
            }   
        }
            
        else if (arrow == 1 && !(transform.position.x >= moveValue))
        {
            if(isD || isRightArrow)
            {
                transform.position += plusVec;
            }
        }
    }

    void Chliking()
    {
        isA = Input.GetKey(KeyCode.A);
        isD = Input.GetKey(KeyCode.D);
        isLeftArrow = Input.GetKey(KeyCode.LeftArrow);
        isRightArrow = Input.GetKey(KeyCode.RightArrow);
        isSpace = Input.GetKey(KeyCode.Space);

        isUltimate = isSpace && isAttackHolding;

        if (!isUltimate)
            isAttack = !isA && !isD && !isLeftArrow && !isRightArrow && !isSpace && Input.anyKey; // 개선 필요 : 움직일 때 공격 불가 ==> 움직여도 공격 o . ad화살표 등 으로 공격이 활성화 x
        
        if (reCastingTime > 0f)
            reCastingTime -= Time.deltaTime;
        else if (reCastingTime <= 0f)
            reCastingTime = 0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 arrowVec = context.ReadValue<Vector2>();
        arrow = arrowVec.x;
    }

    public void OnLastAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isCharging = true;
            Debug.Log("차징 시작");
        }
        else if (context.performed)
        {
            if (reCastingTime == 0f)
                StartCoroutine(RecastS());
        }
        else if (context.canceled)
        {
            isCharging = false;
            Debug.Log("차징 실패");
        }
        
    }

    public void Ultimate()
    {
        if (isUltimate)
        {   
            isAttack = true;
            //Debug.Log("궁극기 시전!!!");
        }
    }


    IEnumerator RecastS()
    {
        isAttackHolding = true;
        Debug.Log("차징 끝");

        yield return new WaitForSeconds(castingTime);

        isAttackHolding = false;
        isCharging = false;
        Debug.Log("궁극기 끝");
        reCastingTime = 20f;
    }

}
