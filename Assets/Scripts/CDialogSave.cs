using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region ������
#endregion

/// <summary>
/// ���� ��� ������ JSON���� �����ϴ� ��ũ��Ʈ �Դϴ�.
/// ��縦 �����ϱ� ���ؼ��� ���ǰ� ���� �ΰ��ӿ����� ������ �ʽ��ϴ�.
/// </summary>
public class CDialogSave : MonoBehaviour
{
    private List<string> p = new List<string>();
    private string r;

    private void Start()
    {
        SaveJSON();
    }

    void SaveJSON()
    {
        p.Add("����� ���̶�� ���� ���� ���� ���ڴ�?");
        p.Add("�װ� ���� �ƴϾ�.");
        p.Add("���� ����� ã�ƶ�.");

        r = "����� �ڸ��� ���ư���.";


        string path = $"{Application.streamingAssetsPath}/Portrait_Dialog.json";
		string json = JsonConvert.SerializeObject(p);
		File.WriteAllText(path, json);

        path = $"{Application.streamingAssetsPath}/Lamp_Dialog.json";
        json = JsonConvert.SerializeObject(r);
        File.WriteAllText(path, json);
    }
}
