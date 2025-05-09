using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class BeatmapData
{
    public int formatVersion;
    public MetaData meta;
    public List<TrackData> tracks;
    public List<EventData> events;

    public BeatmapData()
    {
        meta = new MetaData();
        tracks = new List<TrackData>();
        events = new List<EventData>();
    }
}
