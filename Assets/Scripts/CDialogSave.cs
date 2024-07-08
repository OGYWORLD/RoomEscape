using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region 오가을
#endregion

/// <summary>
/// 라디오 대사 정보를 JSON으로 저장하는 스크립트 입니다.
/// 대사를 저장하기 위해서만 사용되고 실제 인게임에서는 사용되지 않습니다.
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
        p.Add("당신이 빛이라면 가장 먼저 만날 여자는?");
        p.Add("그건 내가 아니야.");
        p.Add("다음 사람을 찾아라.");

        r = "당신의 자리로 돌아가라.";


        string path = $"{Application.streamingAssetsPath}/Portrait_Dialog.json";
		string json = JsonConvert.SerializeObject(p);
		File.WriteAllText(path, json);

        path = $"{Application.streamingAssetsPath}/Lamp_Dialog.json";
        json = JsonConvert.SerializeObject(r);
        File.WriteAllText(path, json);
    }
}
