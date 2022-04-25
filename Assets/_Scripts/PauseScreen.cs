using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject SettingsModal;
    public void PauseGame()
    {
        if (SettingsModal.activeSelf == true)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        SettingsModal.SetActive(!SettingsModal.activeSelf);
    }
}