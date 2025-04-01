using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float horizontalValue;

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

    float arrow;

    void Update()
    {
        Move(arrow);
        Ultimate();
        Chliking();
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
            isAttack = !isA && !isD && !isLeftArrow && !isRightArrow && !isSpace && Input.anyKey;
        
        if (reCastingTime > 0f)
            reCastingTime -= Time.deltaTime;
        else if (reCastingTime <= 0f)
            reCastingTime = 0f;
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 arrowVec = inputValue.Get<Vector2>();
        arrow = arrowVec.x;
    }

    void OnLastAttack()
    {
        if (reCastingTime == 0f)
            StartCoroutine(RecastS());
    }

    public void Ultimate()
    {
        if (isUltimate)
        {   
            isAttack = true;
        }
    }

    IEnumerator RecastS()
    {
        isAttackHolding = true;

        yield return new WaitForSeconds(castingTime);

        isAttackHolding = false;

        reCastingTime = 20f;
    }

}
