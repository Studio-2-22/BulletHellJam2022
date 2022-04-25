using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject MainOptions;

    public void loadGame ()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;  // when you load a scene, the time scale is set to 1

    }
    public void toggleSettings ()
    {
        if(SettingsMenu.activeSelf){
            MainOptions.SetActive(true);
            SettingsMenu.SetActive(false);
        }else{
            SettingsMenu.SetActive(true);
            MainOptions.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
