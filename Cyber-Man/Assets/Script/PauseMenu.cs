using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuH;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void SettingsMenu()
    {
        PauseMenuH.SetActive(false);
    }


      public void QuitOptionMenu()
    {
        PauseMenuH.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
