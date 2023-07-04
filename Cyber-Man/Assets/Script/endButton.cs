using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
