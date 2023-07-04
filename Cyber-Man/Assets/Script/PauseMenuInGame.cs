using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenuInGame : MonoBehaviour
{

    public GameObject PauseMenuInGamelol;
    public GameObject OptionMenu;
    public bool isPaused = false;
    private GUIStyle labelStyle;
    
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuInGamelol.SetActive(false);
        OptionMenu.SetActive(false);
        
        ShowCursor(false);
        // Time of the scene
        Time.timeScale = 1f;
        // GUI curseur
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 25;
        labelStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            PauseGame();
        }
        
    }
    
    private void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    private void OnGUI()
    {
        if (!isPaused)
        {
            float crosshairSize = 20f;
            float labelX = (Screen.width - crosshairSize) / 2f;
            float labelY = (Screen.height - crosshairSize) / 2f;
            GUI.Label(new Rect(labelX, labelY, crosshairSize, crosshairSize), "+", labelStyle);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenuInGamelol.SetActive(true);
        isPaused = true;
        ShowCursor(isPaused);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenuInGamelol.SetActive(false);
        isPaused = false;
        ShowCursor(isPaused);
    }

    public void OptionGame()
    {
        PauseMenuInGamelol.SetActive(false);
        OptionMenu.SetActive(true);
    }


     public void QuitOptionGame()
    {
        OptionMenu.SetActive(false);
        PauseMenuInGamelol.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
