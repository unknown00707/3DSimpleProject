using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
