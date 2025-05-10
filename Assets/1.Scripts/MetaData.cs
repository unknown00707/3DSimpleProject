using UnityEngine;
using System;

[Serializable]
public class MetaData
{
    public string title;
    public string artist;
    public string author;
    public int bpm;
    public string timeSignature;

    public MetaData()
    {
        title = "Untitled Song";
        artist = "Unknown Artist";
        author = "User";
        bpm = 120;
        timeSignature = "4/4";
    }
}
