using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class TrackData
{
    public int trackId;
    public List<NoteData> notes;

    public TrackData()
    {
        notes = new List<NoteData>();
    }
}
