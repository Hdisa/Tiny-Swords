using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] private Castle castle;
    [SerializeField] private List<TargetList> targetLists;
    [SerializeField] private string scene;

    void Update()
    {
        if (castle == null) SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        foreach (TargetList targetList in targetLists) targetList.Clear();
    }
}