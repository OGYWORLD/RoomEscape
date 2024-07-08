using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// ������ �׷��� å�� ����� ��, ���谡 �������Ǵ� ������ �����ϴ� ��ũ��Ʈ�Դϴ�.
/// </summary>
public class CKeyRespawn : MonoBehaviour
{
    public Transform bookTrans; // å transform
    public Transform keyRespawnZone; // ���� ������ transform

    public GameObject keyPrefab; // ���� ������
    private bool isGetKey = false; // ���踦 �������� ���� üũ

    public AudioSource keySound;

    private void Update()
    {
        KeyReswapn();
    }

    void KeyReswapn()
    {
        if (!isGetKey && bookTrans.position.y >= 2f) // å�� position y���� 2 �̻��̸� ���� ������
        {
            keySound.Play();
            isGetKey = true;
            keyPrefab.transform.position = keyRespawnZone.position;
            keyPrefab.SetActive(true);
        }
    }


}
