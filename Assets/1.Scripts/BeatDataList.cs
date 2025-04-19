[System.Serializable]
public class BeatDataList
{
    [System.Serializable]
    public class BeatInfo
    {
        public float time;
        public int line;
        public string type;
    }

    public BeatInfo[] beats;
}