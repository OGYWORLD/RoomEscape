using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 나무가 그려진 책을 들었을 때, 열쇠가 리스폰되는 동작을 실행하는 스크립트입니다.
/// </summary>
public class CKeyRespawn : MonoBehaviour
{
    public Transform bookTrans; // 책 transform
    public Transform keyRespawnZone; // 열쇠 리스폰 transform

    public GameObject keyPrefab; // 열쇠 프리팹
    private bool isGetKey = false; // 열쇠를 가졌는지 여부 체크

    public AudioSource keySound;

    private void Update()
    {
        KeyReswapn();
    }

    void KeyReswapn()
    {
        if (!isGetKey && bookTrans.position.y >= 2f) // 책의 position y값이 2 이상이면 열쇠 리스폰
        {
            keySound.Play();
            isGetKey = true;
            keyPrefab.transform.position = keyRespawnZone.position;
            keyPrefab.SetActive(true);
        }
    }


}
