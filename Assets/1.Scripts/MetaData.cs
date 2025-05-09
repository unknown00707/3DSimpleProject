using UnityEngine;
using System;

[Serializable]
public class MetaData
{
    public string title;
    public string artist;
    public string author;
    public float bpm;
    public string timeSignature;

    public MetaData()
    {
        title = "Untitled Song";
        artist = "Unknown Artist";
        author = "User";
        bpm = 120f;
        timeSignature = "4/4";
    }
}
