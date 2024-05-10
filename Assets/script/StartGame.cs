using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string GameLvl;
    public void StartG()
    {
        SceneManager.LoadScene(GameLvl, LoadSceneMode.Additive);
    }
    public void Menu()
    {
        SceneManager.UnloadSceneAsync(GameLvl);
    }
}
