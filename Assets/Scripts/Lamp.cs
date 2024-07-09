using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class Lamp : MonoBehaviour
{
    [SerializeField] private Light lampLight;
    public GameObject password;

    private bool isLight;
    public bool PreConditionChecked { get; set; } = true;

    public AudioSource switchSound;

    private void Start()
    {
        lampLight = GetComponentInChildren<Light>();
        lampLight.gameObject.SetActive(false);
        password.SetActive(false);

        StartCoroutine(CheckGoalCoroutine());
    }

    public void LightToggle()
    {
        switchSound.Play();
        isLight = !isLight;
        lampLight.gameObject.SetActive(isLight);
    }

    private bool CheckLightOnCorrectTime()
    {
        if(PreConditionChecked && isLight)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    IEnumerator CheckGoalCoroutine()
    {
        yield return new WaitUntil(() => CheckLightOnCorrectTime());
        ShowPassword();
    }

    private void ShowPassword()
    {
        password.SetActive(true);
    }
}
