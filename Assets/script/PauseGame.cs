using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseWindow;
    private static bool GameIsPause = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause == false)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
        
        
    }

    public void Pause()
    {
        PauseWindow.SetActive(true);
        Time.timeScale = 0;
        GameIsPause = true;
    }

    public void Continue()
    {
        PauseWindow.SetActive(false);
        Time.timeScale = 1;
        GameIsPause = false;
    }
}
