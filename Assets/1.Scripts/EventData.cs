using UnityEngine;
using System;

[Serializable]
public class EventData
{
    public float time; // 또는 measure, beat 사용
    public int measure;
    public int beat;
    public string type;
    public object value; // 값의 타입은 이벤트 종류에 따라 달라질 수 있음

    public EventData()
    {
        type = "";
    }
}