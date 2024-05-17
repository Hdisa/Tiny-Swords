using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private GameObject worker;
    
    void Start()
    {
        if(transform.childCount > 0) return;
        Instantiate(worker, transform);
    }
}
