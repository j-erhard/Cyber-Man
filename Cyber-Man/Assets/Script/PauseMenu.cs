using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public void PlayGame()
    {
            SceneManager.LoadScene(1);
    }

    //public void SettingsMenu()
    //{
        //SceneManager.LoadScene("SettingsMenu");
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
