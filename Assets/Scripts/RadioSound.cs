using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#region 김하은(사운드), 오가을(UI)
#endregion

public class RadioSound : MonoBehaviour
{
    public AudioSource Voice1;

    public TextMeshProUGUI dialog;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        dialog.text = GameManager.instance.portraitDialog[0];
        StartCoroutine(TextPrint());
        Voice1.Play();
    }

    IEnumerator TextPrint()
    {
        yield return new WaitForSeconds(3f);

        dialog.text = "";
    }
}
