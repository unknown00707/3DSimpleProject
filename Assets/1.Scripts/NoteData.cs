using UnityEngine;
using System;

[Serializable]
public class NoteData
{
    public int beat;
    public int subdivision;
    public int lane;
    public string type;
    
    // 롱 노트 구현 가능하면 쓸듯
    // public int duration; // 선택 사항
    // public string direction; // 선택 사항
    // public int linkedNoteId; // 선택 사항
    
    public NoteData()
    {
        type = "normal";
    }
}
