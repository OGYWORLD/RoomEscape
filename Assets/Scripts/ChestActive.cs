using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#region ������
#endregion

public class ChestActive : MonoBehaviour
{
    public XRSocketInteractor Socket;
    public GameObject CloseChest;
    public GameObject OpenChest;
    public GameObject Key;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        CloseChest.SetActive(false);
        Key.SetActive(false);
        OpenChest.SetActive(true);
    }
}
