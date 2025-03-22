using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float horizontalValue;

    Vector3 plusVec = new Vector3 (2, 0, 0);

    int moveValue = 2;

    bool isA;
    bool isD;
    bool isLeftArrow;
    bool isRightArrow;

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        Move(horizontalValue);
        
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
        isA = Input.GetKeyDown(KeyCode.A);
        isD = Input.GetKeyDown(KeyCode.D);
        isLeftArrow = Input.GetKeyDown(KeyCode.LeftArrow);
        isRightArrow = Input.GetKeyDown(KeyCode.RightArrow);
    }

}
