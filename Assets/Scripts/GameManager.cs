using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region ������
#endregion

public class GameManager : MonoBehaviour
{
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

        LoadJSON();
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
