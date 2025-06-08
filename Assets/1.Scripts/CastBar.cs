using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{

    public PlayerControl player;
    public Image castIMG;
    public GameObject[] childGameObjs;

    float culTime = 0f;

    // Update is called once per frame
    void LateUpdate()
    {
        CulChargingBarSize();
        TimingOfBar();
    }

    void CulChargingBarSize()
    {
        if (player.isCharging && player.reCastingTime <= 0f)
        { 
            culTime += Time.deltaTime;
        }
        else if (!player.isCharging && !player.isUltimate)
        {
            culTime -= Time.deltaTime;
        }    
        
        float culTimeTotal = culTime/0.5f;
        
        if(culTimeTotal >= 1 && player.isUltimate)
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

    void TimingOfBar()
    {
        if(player.isSpace && player.reCastingTime <= 0f)
        {
            foreach (GameObject obj in childGameObjs)
            {
                obj.SetActive(true);
            }
        }
        else if (castIMG.transform.localScale.x == 0)
        {
            foreach (GameObject obj in childGameObjs)
            {
                obj.SetActive(false);
            }
        }
    }
}
