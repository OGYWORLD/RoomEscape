using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#region ±Ë«œ¿∫
#endregion

public class RadioSound : MonoBehaviour
{
    public AudioSource Voice1;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Voice1.Play();
    }
}
