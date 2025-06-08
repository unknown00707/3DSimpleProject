using Newtonsoft.Json;
using UnityEngine;
using System.IO;

public class MusicManager : MonoBehaviour
{
    public string jsonFileName = "testJson.json"; // 로드할 JSON 파일 이름

    private BeatmapData loadedBeatmap;

    void Start()
    {
        LoadBeatmapData();

        if (loadedBeatmap != null)
        {
            //Debug.Log($"곡 제목: {loadedBeatmap.meta.title}, BPM: {loadedBeatmap.meta.bpm}");

            if (loadedBeatmap.tracks != null)
            {
                foreach (var track in loadedBeatmap.tracks)
                {
                    //Debug.Log($"트랙 ID: {track.trackId}, 노트 수: {track.notes.Count}");
                    // 추가적인 트랙 정보 처리
                }
            }

            // 로드된 채보 데이터 활용 (예: 오브젝트 스폰)
            ProcessBeatmapData();
        }
        else
        {
            Debug.LogError("채보 데이터 로드 실패!");
        }
    }

    void LoadBeatmapData()
    {
        // 1. JSON 파일 경로 설정
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        // 2. 파일 존재 확인
        if (File.Exists(filePath))
        {
            // 3. JSON 파일 읽기
            string jsonString = File.ReadAllText(filePath);

            // 4. JSON 데이터 역직렬화 (Deserialize)
            loadedBeatmap = JsonConvert.DeserializeObject<BeatmapData>(jsonString);
        }
        else
        {
            Debug.LogError($"JSON 파일을 찾을 수 없습니다: {filePath}");
            loadedBeatmap = null;
        }
    }

    void ProcessBeatmapData()
    {
        if (loadedBeatmap == null || loadedBeatmap.tracks == null) return;

        // 로드된 채보 데이터를 기반으로 오브젝트를 스폰하는 로직 구현 (추후 작성)
        foreach (var track in loadedBeatmap.tracks)
        {
            foreach (var note in track.notes)
            {
                // 노트 정보를 사용하여 오브젝트 스폰 타이밍 및 위치 계산 (추후 작성)
                //Debug.Log($"트랙: {track.trackId}, 노트 - 박자: {note.beat}, 분박: {note.subdivision}, 레인: {note.lane}, 타입: {note.type}");
            }
        }
    }

    // 필요하다면 로드된 BeatmapData를 외부에서 접근할 수 있도록 하는 Getter 함수
    public BeatmapData GetLoadedBeatmapData()
    {
        return loadedBeatmap;
    }
}