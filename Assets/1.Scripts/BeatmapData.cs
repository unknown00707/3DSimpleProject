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
}
