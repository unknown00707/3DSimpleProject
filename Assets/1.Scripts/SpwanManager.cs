using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpwanManager : MonoBehaviour
{
    
    public Vector3[] pos;

    public Vector3 StartPos()
    {
        int ran = Random.Range(0, 3);
        return pos[ran];
    }
}
