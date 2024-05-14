using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Crystal crystal;
    
    void Update()
    {
        if (crystal == null) GameOver();
    }

    private void GameOver()
    {
        Debug.Log("DOOMED");
    }
}
