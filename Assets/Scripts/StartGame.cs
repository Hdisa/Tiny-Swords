using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string scene;

    public void SwitchLevel()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
