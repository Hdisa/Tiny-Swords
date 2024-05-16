using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Crystal crystal;
    [SerializeField] private List<TargetList> targetLists;

    void Update()
    {
        if (crystal == null) GameOver();
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