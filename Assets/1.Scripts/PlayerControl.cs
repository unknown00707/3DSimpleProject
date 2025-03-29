using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float horizontalValue;

    Vector3 plusVec = new Vector3 (2, 0, 0);

    int moveValue = 1;
    float castingTime = 3f;

    bool isA;
    bool isD;
    bool isLeftArrow;
    bool isRightArrow;
    bool isSpace;

    public bool isAttack;
    public bool isAttackHolding;
    public bool isUltimate;

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
        isSpace = Input.GetKeyDown(KeyCode.Space);

        if(!isUltimate)
            isAttack = !isA && !isD && !isLeftArrow && !isRightArrow && !isSpace && Input.anyKey;

        isUltimate = isSpace && isAttackHolding;
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 arrowVec = inputValue.Get<Vector2>();
        arrow = arrowVec.x;
    }

    void OnLastAttack()
    {
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
    }

}
