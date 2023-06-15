using UnityEngine;

public class AffichageSouris : MonoBehaviour
{
    public bool cursorVisible = false;
    private GUIStyle labelStyle;
    
    private void Start()
    {
        ShowCursor(false);
        Time.timeScale = 1f;
        
        // GUI curseur
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 25;
        labelStyle.normal.textColor = Color.white;
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

    private void OnGUI()
    {
        if (!cursorVisible)
        {
            float crosshairSize = 20f;
            float labelX = (Screen.width - crosshairSize) / 2f;
            float labelY = (Screen.height - crosshairSize) / 2f;
            GUI.Label(new Rect(labelX, labelY, crosshairSize, crosshairSize), "+", labelStyle);
        }
    }
}
