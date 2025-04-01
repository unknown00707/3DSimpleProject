using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{

    public PlayerControl player;
    public GameObject CastBarGroup;
    public Image castIMG;

    float culTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.reCastingTime == 0)
        {
            gameObject.SetActive(true);     

            if (player.isAttackHolding == true)
                culTime -= Time.deltaTime;
            else
                culTime += Time.deltaTime;
            
            float culTimeTotal = culTime/0.5f;
                
            if(culTimeTotal >= 1)
            {
                culTime = 0.5f;
                culTimeTotal = 1;
            }      
            else if (culTimeTotal <= 0)
            {
                culTime = 0;
                culTimeTotal = 0;
            }
                    
                
            castIMG.transform.localScale = new Vector2(culTimeTotal, 1);
        }    
    }
}
