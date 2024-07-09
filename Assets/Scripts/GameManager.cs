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
    public enum Stage
    {
        Nothing,
        Apple,
        Portrait,
        Light
    }

    public static GameManager instance { get; private set; }
    public List<string> portraitDialog { get; set; } = new List<string>(); // ���� ���� ��� ����Ʈ
    public string lampDialog { get; set; } // ���� ���� ���

    public Stage curStage { get; set; } = Stage.Nothing; // ���� ��������

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
    /// �ȵ���̵� ���� ȯ�濡�� JSON ������ Load�ϴ� ������ ��� �ڷ�ƾ�Դϴ�.
    /// UnityWebRequest�� ����Ͽ� JSON �����͸� ó���ϵ��� �����߽��ϴ�.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Portrait_Dialog.json");

        /* Android ���� ȯ�濡���� Streaming Assets���� ��ο� //�� ���Ե��� �̿��Ͽ�
         * �ش� ���α׷��� ���� ���� �÷��� ���θ� Ȯ���մϴ�.
         */
        if (filePath.Contains("://") || filePath.Contains(":///")) // Android
        {
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            
            // filePath�� HTTP GET ��û�� �Ͽ� �ش� ��û�� ������ SendWebRequest�� ���� �޽��ϴ�. 
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
        else // Window ȯ�濡�� JSON ���� �ε�
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
