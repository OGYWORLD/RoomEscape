using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.IO;

#region 오가을
#endregion

public class GameManager : MonoBehaviour
{
    public enum Stage
    {
        Nothing,
        Apple,
        Portrait,
        Light
    }

    public static GameManager instance { get; private set; }
    public List<string> portraitDialog { get; set; } = new List<string>(); // 액자 라디오 대사 리스트
    public string lampDialog { get; set; } // 램프 라디오 대사

    public Stage curStage { get; set; } = Stage.Nothing; // 현재 스테이지

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //LoadJSON();
    }

    private void Start()
    {
        StartCoroutine(LoadJson());
    }

    /// <summary>
    /// 안드로이드 빌드 환경에서 JSON 파일을 Load하는 동작이 담긴 코루틴입니다.
    /// UnityWebRequest를 사용하여 JSON 데이터를 처리하도록 구현했습니다.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Portrait_Dialog.json");

        /* Android 빌드 환경에서의 Streaming Assets폴더 경로에 //가 포함됨을 이용하여
         * 해당 프로그램이 실행 중인 플랫폼 여부를 확인합니다.
         */
        if (filePath.Contains("://") || filePath.Contains(":///")) // Android
        {
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            
            // filePath에 HTTP GET 요청을 하여 해당 요청의 응답을 SendWebRequest를 통해 받습니다. 
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("ERROR!");
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                portraitDialog = JsonConvert.DeserializeObject<List<string>>(jsonText);
            }
        }
        else // Window 환경에서 JSON 파일 로드
        {
            if (File.Exists(filePath))
            {
                string jsonText = File.ReadAllText(filePath);
                portraitDialog = JsonConvert.DeserializeObject<List<string>>(jsonText);
            }
            else
            {
                Debug.LogError("ERROR!");
            }
        }
    }
}
