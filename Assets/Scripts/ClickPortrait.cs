using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#region 김하은
#endregion

[RequireComponent(typeof(AudioSource))]
public class ClickPortrait : MonoBehaviour
{
    [SerializeField]
    private int FrameNum;

    public PortraitManager manager;

    private int[] CorrectNum = { 1, 2, 3, 4 };

    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioClip FinalSound;

    public AudioSource Audio;

    public void OnInteract()
    {
        if (CorrectNum[manager.Now] == FrameNum)
        {
            Debug.Log("맞음");
            Audio.clip = CorrectSound;
            Audio.Play();

            manager.Now++;

            if (manager.Now >= CorrectNum.Length)
            {
                Debug.Log("다 맞음");
                Audio.clip = FinalSound;
                Audio.Play();

                manager.Now = 0;
            }
        }

        else
        {
            Debug.Log("틀림");
            Audio.clip = WrongSound;
            Audio.Play();

            manager.Now = 0;
        }
    }
}
