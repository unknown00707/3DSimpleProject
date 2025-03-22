using UnityEngine;

public class MoveForever : MonoBehaviour
{
    [SerializeField] float speed = 60;
    [SerializeField] float limitZvalue;
    
    Vector3 startPos = new Vector3(0,0, 200);


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
        
    }

    void LateUpdate()
    {
         if (transform.position.z < limitZvalue)
        {
            transform.position = startPos;
        }
    }
}
