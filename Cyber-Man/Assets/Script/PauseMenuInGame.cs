using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenuInGame : MonoBehaviour
{

    public GameObject PauseMenuInGamelol;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuInGamelol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
        }
        
    }

    public void PauseGame()
    {
        PauseMenuInGamelol.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuInGamelol.SetActive(false);
        Console.WriteLine("lol");
        isPaused = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
