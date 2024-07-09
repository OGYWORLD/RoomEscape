using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.IO;

#region ������
#endregion

public class GameManager : MonoBehaviour
{
    public enum Radio
    {
        FindPortrait,
        Corret,
        Wrong
    }

    public static GameManager instance { get; private set; }
    public List<string> portraitDialog { get; set; } = new List<string>(); // ���� ���� ��� ����Ʈ
    public string lampDialog { get; set; } // ���� ���� ���



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

    IEnumerator LoadJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Portrait_Dialog.json");

        // Android
        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                portraitDialog = JsonConvert.DeserializeObject<List<string>>(jsonText);
            }
        }
        else // Window
        {
            if (File.Exists(filePath))
            {
                string jsonText = File.ReadAllText(filePath);
                portraitDialog = JsonConvert.DeserializeObject<List<string>>(jsonText);
            }
            else
            {
                Debug.LogError("File not found at " + filePath);
            }
        }
    }

    /// <summary>
    /// ���� ��縦 List�� �ҷ����� �Լ� �Դϴ�.
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
