using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 플레이 시간을 측정하는 스크립트 입니다.
/// </summary>

public class CPlayTime : MonoBehaviour
{
    private float playTime;

    public TextMeshProUGUI playTimeTMP;

    public AudioSource bgmPlayer;
    public AudioClip winBGM;

    private bool isEnd = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isEnd)
        {
            isEnd = true;

            bgmPlayer.Stop();
            bgmPlayer.clip = winBGM;
            bgmPlayer.Play();

            float t = Time.time;

            float h = (int)(t / 360);
            float m = (int)((t % 360) / 60);
            float s = (int)((t % 360) % 60);

            playTimeTMP.text = "" + h + "H " + m + "M " + s + "S";
        }
    }


}
