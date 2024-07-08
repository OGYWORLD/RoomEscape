using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region 오가을
#endregion

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public List<string> portraitDialog { get; set; } = new List<string>(); // 액자 라디오 대사 리스트
    public string lampDialog { get; set; } // 램프 라디오 대사



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

        LoadJSON();
    }

    /// <summary>
    /// 라디오 대사를 List에 불러오는 함수 입니다.
    /// </summary>
    void LoadJSON()
    {
        string path = $"{Application.streamingAssetsPath}/Portrait_Dialog.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            portraitDialog = JsonConvert.DeserializeObject<List<string>>(json);
        }

        path = $"{Application.streamingAssetsPath}/Lamp_Dialog.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            lampDialog = JsonConvert.DeserializeObject<string>(json);
        }
    }
}
