using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] private Castle castle;
    [SerializeField] private List<TargetList> targetLists;

    void Update()
    {
        if (castle == null) GameOver();
    }

    private void GameOver()
    {
        Debug.Log("DOOMED");
    }

    private void OnDestroy()
    {
        foreach (TargetList targetList in targetLists) targetList.Clear();
    }
}