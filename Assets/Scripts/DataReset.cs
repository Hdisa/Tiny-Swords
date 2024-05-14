using UnityEngine;

public class DataReset : MonoBehaviour
{
    [SerializeField] private GameResources resources;

    private void Start()
    {
        resources.coins = 100;
    }
}
