using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#region ±Ë«œ¿∫
#endregion

public class CoinActive : MonoBehaviour
{
    public GameObject Coin;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Coin.SetActive(false);

        GameManager.instance.curStage = GameManager.Stage.Apple;
    }
}