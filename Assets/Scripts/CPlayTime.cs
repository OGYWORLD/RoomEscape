using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �÷��� �ð��� �����ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>

public class CPlayTime : MonoBehaviour
{
    private float playTime;

    public TextMeshProUGUI playTimeTMP;

    private bool isEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isEnd)
        {
            isEnd = true;

            float t = Time.time;

            float h = (int)(t / 360);
            float m = (int)((t % 360) / 60);
            float s = (int)((t % 360) % 60);

            playTimeTMP.text = "" + h + "H " + m + "M " + s + "S";
        }
    }


}
