using UnityEngine;

public class CreatingAWorker : MonoBehaviour
{
    public GameObject Worker;
    
    
    void Start()
    {
        if(transform.childCount > 0) return;
        Instantiate(Worker, transform);
    }

}
