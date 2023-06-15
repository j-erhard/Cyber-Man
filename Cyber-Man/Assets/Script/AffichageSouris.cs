using UnityEngine;

public class AffichageSouris : MonoBehaviour
{
    public bool cursorVisible = false;
    
    private void Start()
    {
        ShowCursor(false);
        Time.timeScale = 1f;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cursorVisible)
        {
            cursorVisible = false;
            ShowCursor(cursorVisible);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && cursorVisible == false)
        {
            cursorVisible = true;
            ShowCursor(cursorVisible);
            Time.timeScale = 0f;
        }
    }
    
    private void ShowCursor(bool show)
    {
        cursorVisible = show;
        Cursor.visible = cursorVisible;
        Cursor.lockState = cursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
