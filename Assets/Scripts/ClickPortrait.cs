using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

#region 김하은(사운드, 상호작용), 오가을(UI)
#endregion

[RequireComponent(typeof(AudioSource))]
public class ClickPortrait : MonoBehaviour
{
    [SerializeField]
    private int FrameNum;

    private bool isSolved;

    public PortraitManager manager;

    private int[] CorrectNum = { 1, 2, 3, 4 };

    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioClip FinalSound;

    public AudioSource Audio;

    public TextMeshProUGUI dialog;

    public void OnInteract()
    {
        if(GameManager.instance.curStage == GameManager.Stage.Apple)
        {
            if (isSolved || CorrectNum[manager.Now] == FrameNum)
            {
                if (manager.Now >= CorrectNum.Length - 1)
                {
                    isSolved = true;
                    dialog.text = "당신의 처음 위치로 돌아가라.";
                    StartCoroutine(TextPrint());

                    Audio.clip = FinalSound;
                    Audio.Play();

                    GameManager.instance.curStage = GameManager.Stage.Portrait;
                }
                else
                {
                    dialog.text = GameManager.instance.portraitDialog[2];
                    StartCoroutine(TextPrint());

                    Audio.clip = CorrectSound;
                    Audio.Play();

                    manager.Now++;
                }
            }

            else
            {
                dialog.text = GameManager.instance.portraitDialog[1];
                StartCoroutine(TextPrint());

                Audio.clip = WrongSound;
                Audio.Play();

                manager.Now = 0;
            }
        }
    }

    IEnumerator TextPrint()
    {
        yield return new WaitForSeconds(3f);

        dialog.text = "";
    }
}
