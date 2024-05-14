using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseWindow;
    private static bool isPause;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause == false)
                Pause();
            else
                Continue();
        }
    }

    public void Pause()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void Continue()
    {
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }
}
